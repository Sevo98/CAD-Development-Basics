using Core;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace Kompas
{
	public class Builder
	{
		/// <summary>
		/// Экземпляр класса параметров
		/// </summary>
		private Parameters _parameters;

		/// <summary>
		/// Экземпляр компонента сборки
		/// </summary>
		private ksPart _part;

		/// <summary>
		/// Соединение с КОМПАС-3D
		/// </summary>
		private KompasWrapper _kompas = new KompasWrapper();

		/// <summary>
		/// Конструктор класса
		/// </summary>
		/// <param name="parameters">Экземпляр параметров</param>
		public Builder(Parameters parameters)
		{
			_kompas.Start();
			var document3D = _kompas.CreateDocument3D();
			_part = document3D.GetPart((short)Part_Type.pTop_Part);
			_parameters = parameters;
		}

		/// <summary>
		/// Построитель тумбы
		/// </summary>
		public void BuildModel()
		{
			CreateArea();
			CreateHead();
			CreateShell();
			CreateCover();
			CreateHoles();
			CreateFillet();
		}

		/// <summary>
		/// Построитель нижней площадки
		/// </summary>
		private void CreateArea()
		{
			ksEntity planeXOY = 
				_part.GetDefaultEntity((short)ksObj3dTypeEnum.o3d_planeXOY);
			ksEntity sketch = CreateSketch(planeXOY, out var sketchDefinition);

			ksDocument2D document2D = sketchDefinition.BeginEdit();
			var xCenter = 0;
			var yCenter = 0;
			Circle(document2D, _parameters.DiameterArea, xCenter,yCenter);

			sketchDefinition.EndEdit();
			Extrusion(_parameters.DepthBoltThreadHoles, sketch, true);
		}

		/// <summary>
		/// Построитель тела тумбы
		/// </summary>
		private void CreateHead()
		{
			var offset = _parameters.DepthBoltThreadHoles;
			var plane = ksObj3dTypeEnum.o3d_planeXOY;
			ksEntity offsetPlane = CreateOffsetPlane(offset, plane);
			var bollard = CreateBollardSketch(offsetPlane);

			var height = _parameters.HeightBody + _parameters.HeightEdge;
			Extrusion(height, bollard, true);

			var leg = CreateLeg(offsetPlane);

			height = _parameters.HeightBody;
			CutExtrusion(height, leg, false);

		}

		/// <summary>
		/// Создаёт эскиз тумбы
		/// </summary>
		/// <param name="plane">Плоскость эскиза</param>
		/// <returns>Указатель на готовый эскиз</returns>
		private ksEntity CreateBollardSketch(ksEntity plane)
		{
			ksEntity sketch = CreateSketch(plane, out var sketchDefinition);
			ksDocument2D document2D = sketchDefinition.BeginEdit();
			//Первая дуга
			var xCenter = 0;
			var yCenter = 0;
			var baseCircle = Circle(document2D, _parameters.DiameterBody, xCenter, yCenter);
			var xCircle = 0;
			var yCircle = _parameters.DiameterBody / 2;
			TrimCurve(document2D, baseCircle, xCircle, yCircle,
				xCircle, -yCircle, yCircle, xCircle);

			//Вторые дуги
			var radiusSecondCircle = 75;
			yCenter = _parameters.DiameterBody / 2 + radiusSecondCircle;
			var secondCircle = Circle(document2D, radiusSecondCircle * 2, xCenter, yCenter);
			TrimCurve(document2D, secondCircle, xCircle, yCircle, -radiusSecondCircle,
				yCircle + radiusSecondCircle, -radiusSecondCircle, xCircle);
			yCenter = -yCenter;
			secondCircle = Circle(document2D, radiusSecondCircle * 2, xCenter, yCenter);
			TrimCurve(document2D, secondCircle, xCircle, -yCircle, -radiusSecondCircle,
				-(yCircle + radiusSecondCircle), -radiusSecondCircle, xCircle);

			//Третьи дуги
			var radiusThirdCircle = 100;
			xCenter = -(radiusThirdCircle + radiusSecondCircle);
			yCenter = _parameters.DiameterBody / 2 + radiusSecondCircle;

			var thirdCircle = Circle(document2D, radiusThirdCircle * 2, xCenter, yCenter);
			xCircle = -radiusSecondCircle;
			yCircle = yCenter;
			TrimCurve(document2D, thirdCircle, xCircle, yCircle, -yCircle,
				yCircle, xCenter, yCenter * 2);

			yCenter = -yCenter;
			yCircle = yCenter;
			thirdCircle = Circle(document2D, radiusThirdCircle * 2, xCenter, yCenter);
			TrimCurve(document2D, thirdCircle, xCircle, yCircle, yCircle,
				yCircle, xCenter, yCenter * 2);

			//Отрезок
			document2D.ksLineSeg(yCenter, yCenter,
				yCenter, -yCenter, (short)ksCurveStyleEnum.ksCSNormal);

			sketchDefinition.EndEdit();

			return sketch;
		}
		/// <summary>
		/// Построитель ножки тумбы
		/// </summary>
		/// <param name="plane"></param>
		/// <returns></returns>
		private ksEntity CreateLeg(ksEntity plane)
		{
			ksEntity sketch = CreateSketch(plane, out var sketchDefinition);
			ksDocument2D document2D = sketchDefinition.BeginEdit();
			var xCenter = 0;
			var yCenter = 0;
			Circle(document2D, _parameters.DiameterBody, xCenter, yCenter);
			Circle(document2D, _parameters.DiameterArea*2, xCenter, yCenter);
			sketchDefinition.EndEdit();
			return sketch;
		}

		/// <summary>
		/// Операция "Оболочка"
		/// </summary>
		private void CreateShell()
		{
			var x = 0;
			var y = 0;
			ksEntity shell = _part.NewEntity((short) ksObj3dTypeEnum.o3d_shellOperation);
			ksShellDefinition shellDefinition = shell.GetDefinition();
			shellDefinition.thickness = 20;
			shellDefinition.thinType = true;

			ksEntityCollection faceCollection =
				_part.EntityCollection((short)ksObj3dTypeEnum.o3d_face);
			var length = _parameters.HeightBody + _parameters.HeightEdge 
			                                    + _parameters.DepthBoltThreadHoles;
			faceCollection.SelectByPoint(x, y, length);

			ksEntity face = faceCollection.First();
			ksEntityCollection entityCollection = shellDefinition.FaceArray();
			entityCollection.Add(face);

			shell.Create();
		}

		/// <summary>
		/// Построитель крышки тумбы
		/// </summary>
		private void CreateCover()
		{
			var offset = _parameters.HeightBody + _parameters.HeightEdge
			                                    + _parameters.DepthBoltThreadHoles;
			var plane = ksObj3dTypeEnum.o3d_planeXOY;
			var offsetPlane = CreateOffsetPlane(offset, plane);
			var sketch = CreateBollardSketch(offsetPlane);
			var length = 20;
			Extrusion(length, sketch, false);

			var diameterHole = 100;
			var holeX = 0;
			var holeY = 0;
			ksEntity hole = CreateSketch(offsetPlane, out var sketchDefinition);
			ksDocument2D document2D = sketchDefinition.BeginEdit();
			Circle(document2D, diameterHole, holeX, holeY);
			sketchDefinition.EndEdit();
			CutExtrusion(length, hole, true);
		}

		/// <summary>
		/// Построитель отверстий под болты
		/// </summary>
		private void CreateHoles()
		{
			var diameterAxisCircle =
				_parameters.DiameterArea - (_parameters.DiameterArea - _parameters.DiameterBody) / 2;
			var offset = _parameters.DepthBoltThreadHoles;
			var plane = ksObj3dTypeEnum.o3d_planeXOY;
			var xHole = diameterAxisCircle / 2;
			var yHole = 0;
			var diameterHoles = _parameters.DiameterBoltThreadHoles;

			ksEntity offsetPlane = CreateOffsetPlane(offset, plane);
			ksEntity sketch = CreateSketch(offsetPlane, out var sketchDefinition);
			ksDocument2D document2D = sketchDefinition.BeginEdit();
			Circle(document2D, diameterHoles, xHole, yHole);
			sketchDefinition.EndEdit();
			var threadHole = CutExtrusion(_parameters.DepthBoltThreadHoles,
				sketch, true);
			CircularCopy(threadHole);

			sketch = CreateSketch(offsetPlane, out sketchDefinition);
			document2D = sketchDefinition.BeginEdit();
			diameterHoles = _parameters.DiameterBoltHeadHoles;
			Circle(document2D, diameterHoles, xHole, yHole);
			sketchDefinition.EndEdit();
			var headHole = CutExtrusion(_parameters.DepthBoltHeadHoles,
				sketch, true);
			CircularCopy(headHole);
		}

		/// <summary>
		/// Операция "массив по концентрической сетке"
		/// </summary>
		/// <param name="entity">Объект копирования</param>
		private void CircularCopy(ksEntity entity)
		{
			ksEntity copy = _part.NewEntity((short)ksObj3dTypeEnum.o3d_circularCopy);
			ksCircularCopyDefinition copyDefinition = copy.GetDefinition();
			ksEntityCollection holeArray = copyDefinition.GetOperationArray();
			holeArray.Add(entity);
			ksEntity axisOZ =
				_part.GetDefaultEntity((short)ksObj3dTypeEnum.o3d_axisOZ);

			copyDefinition.SetAxis(axisOZ);
			copyDefinition.count2 = 8;
			copyDefinition.factor2 = false;
			copyDefinition.step2 = 45;
			copy.Create();
		}

		/// <summary>
		/// Построитель скругления
		/// </summary>
		private void CreateFillet()
		{
			ksEntityCollection faceCollection =
				_part.EntityCollection((short)ksObj3dTypeEnum.o3d_face);
			var faceX = _parameters.DiameterArea / 2;
			var faceY = 0;
			var faceZ = _parameters.DepthBoltThreadHoles / 2;
			faceCollection.SelectByPoint(faceX, faceY, faceZ);

			ksEntity face = faceCollection.First();
			Fillet(face);
			
			faceX = _parameters.DiameterBody / 2;
			faceZ = _parameters.HeightBody + _parameters.HeightEdge;

			faceCollection =
				_part.EntityCollection((short)ksObj3dTypeEnum.o3d_face);
			faceCollection.SelectByPoint(faceX, faceY, faceZ);

			ksEntity anotherFace = faceCollection.First();
			Fillet(anotherFace);
		}

		/// <summary>
		/// Операция "Скругление"
		/// </summary>
		/// <param name="face">Грань скругления</param>
		private void Fillet(ksEntity face)
		{
			ksEntity fillet = _part.NewEntity((short)ksObj3dTypeEnum.o3d_fillet);

			ksFilletDefinition filletDefinition = fillet.GetDefinition();

			filletDefinition.radius = 10;
			filletDefinition.tangent = false;

			ksEntityCollection entityCollectionFillet = filletDefinition.array();
			entityCollectionFillet.Add(face);

			fillet.Create();

		}

		/// <summary>
		/// Метод создания эскиза
		/// </summary>
		/// <param name="plane">Плоскость</param>
		/// <param name="sketchDefinition">Параметры эскиза</param>
		/// <returns>Указатель на эскиз</returns>
		private ksEntity CreateSketch(ksEntity plane, out ksSketchDefinition sketchDefinition)
		{
			ksEntity sketch = _part.NewEntity((short)ksObj3dTypeEnum.o3d_sketch);
			sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();
			return sketch;
		}

		/// <summary>
		/// Метод постройки окружности
		/// </summary>
		/// <param name="document2D">Интерфейс графического документа</param>
		/// <param name="diameter">Диаметр круга</param>
		/// <param name="xCenter">X координата центра</param>
		/// <param name="yCenter">Y координата центра</param>
		private int Circle(ksDocument2D document2D, double diameter, double xCenter, double yCenter)
		{
			var circle = document2D.ksCircle(xCenter, yCenter, diameter / 2,
				(short)ksCurveStyleEnum.ksCSNormal);
			return circle;
		}

		/// <summary>
		/// Метод выдавливания
		/// </summary>
		/// <param name="length">Длина выдавливания</param>
		/// <param name="sketch">Эскиз выдавливания</param>
		/// <param name="directly">Прямое направление</param>
		private void Extrusion(double length, ksEntity sketch, bool directly)
		{
			ksEntity extrusion =
				_part.NewEntity((short)ksObj3dTypeEnum.o3d_baseExtrusion);
			ksBaseExtrusionDefinition extrusionDefinition = extrusion.GetDefinition();

			extrusionDefinition.SetSideParam(directly,
				(short)ksEndTypeEnum.etBlind, length);

			extrusionDefinition.directionType =
				directly ? (short) ksDirectionTypeEnum.dtNormal : (short) ksDirectionTypeEnum.dtReverse;

			extrusionDefinition.SetSketch(sketch);
			extrusion.Create();
		}

		/// <summary>
		/// Метод создания смещённой плоскости
		/// </summary>
		/// <param name="offset">расстояние смещения</param>
		/// <param name="plane">базовая плоскость</param>
		/// <returns>Указатель на смещённую плоскость</returns>
		private ksEntity CreateOffsetPlane(double offset, ksObj3dTypeEnum plane)
		{
			ksEntity defaultPlane =
				_part.GetDefaultEntity((short)plane);
			ksEntity planeOffset =
				_part.NewEntity((short)ksObj3dTypeEnum.o3d_planeOffset);
			ksPlaneOffsetDefinition planeOffsetDefinition = planeOffset.GetDefinition();

			planeOffsetDefinition.direction = true;
			planeOffsetDefinition.offset = offset;

			planeOffsetDefinition.SetPlane(defaultPlane);

			planeOffset.Create();
			return planeOffset;
		}

		/// <summary>
		/// Метод вырезания выдавливанием
		/// </summary>
		/// <param name="length">Длина вырезания</param>
		/// <param name="sketch">Вырезаемый эскиз</param>
		/// <param name="directly">Прямое направление</param>
		private ksEntity CutExtrusion(double length, ksEntity sketch, bool directly)
		{
			ksEntity cutExtrusion =
				_part.NewEntity((short)ksObj3dTypeEnum.o3d_cutExtrusion);
			ksCutExtrusionDefinition cutExtrusionDefinition =
				cutExtrusion.GetDefinition();

			cutExtrusionDefinition.SetSideParam(directly, (short)ksEndTypeEnum.etBlind, length);
			cutExtrusionDefinition.cut = true;
			cutExtrusionDefinition.directionType =
				directly ? (short)ksDirectionTypeEnum.dtNormal : (short)ksDirectionTypeEnum.dtReverse;

			cutExtrusionDefinition.SetSketch(sketch);
			cutExtrusion.Create();
			return cutExtrusion;
		}

		/// <summary>
		/// Усечь кривую, оставив часть между точками
		/// </summary>
		/// <param name="document2D">Интерфес графического документа</param>
		/// <param name="curve">Усекаемая кривая</param>
		/// <param name="xBegin">Координата X начала</param>
		/// <param name="yBegin">Координата Y начала</param>
		/// <param name="xEnd">Координата X конца</param>
		/// <param name="yEnd">Координата Y конца</param>
		/// <param name="xOn">Координата X точки лежащей на кривой</param>
		/// <param name="yOn">Координата Y точки лежащей на кривой</param>
		private void TrimCurve(ksDocument2D document2D, int curve,
			double xBegin, double yBegin, double xEnd, double yEnd, double xOn, double yOn)
		{
			document2D.ksTrimmCurve(curve, xBegin, yBegin,
				xEnd, yEnd, xOn, yOn,
				(short)ViewMode.vm_HiddenRemoved);
		}

	}
}
