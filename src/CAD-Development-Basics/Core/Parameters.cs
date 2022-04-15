using System;


namespace Core
{
    //TODO: XML
    /// <summary>
    /// Список параметров детали
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Диаметр площадки тумбы
        /// </summary>
        private int _diameterArea;
       
        /// <summary>
        /// Высота козырька
        /// </summary>
        private int _heightEdge;
        
        /// <summary>
        /// Диаметр тела тумбы
        /// </summary>
        private int _diameterBody;
        
        /// <summary>
        /// Высота тела тумбы
        /// </summary>
        private int _heightBody;
       
        /// <summary>
        /// Длина козырька
        /// </summary>
        private int _lengthVisor;
       
        /// <summary>
        /// Высота козырька
        /// </summary>
        private int _heightVisor;
       
        /// <summary>
        /// Диаметр отверствия для головки болта
        /// </summary>
        private int _diameterBoltHeadHoles;
       
        /// <summary>
        /// Глубина отверстия для головки болта
        /// </summary>
        private int _depthBoltHeadHoles;
        
        /// <summary>
        /// Глубина отверстия для резьбы болта
        /// </summary>
        private int _depthBoltThreadHoles;
        
        /// <summary>
        /// Диаметр отверстия для резьбы болта
        /// </summary>
        private int _diameterBoltThreadHoles;
       
        /// <summary>
        /// Проверка диаметра площадки
        /// </summary>
        public int DiameterArea
        {
            get => _diameterArea;
            set
            {
                const int minValue = 600;
                const int maxValue = 1350;
                //try
                //{
                //    ValidateValue(value, minValue, maxValue);
                //}
                //catch (Exception e)
                //{
                //    throw new ArgumentException("Введены неправильные параметры!");
                //}

                if (!ValidateValue(value, minValue, maxValue))
                {
                    throw new ArgumentException("Введены неправильные параметры!");
                }

                _diameterArea = value;
            }
        }

        /// <summary>
        /// Проверка высоты тела
        /// </summary>
        public int HeightBody
        {
            get => _heightBody;
            set
            {
                const int minValue = 350;
                const int maxValue = 780;

                try
                {
                    ValidateValue(value, minValue, maxValue);
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Введены неправильные параметры!");
                }

                _heightBody = value;
            }
        }

        /// <summary>
        /// Проверка высоты козырька
        /// </summary>
        public int HeightEdge
        {
            get => _heightEdge;
            set
            {
                const int minValue = 110;
                const int maxValue = 240;
                try
                {
                    ValidateValue(value, minValue, maxValue);
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Введены неправильные параметры!");
                }

                if (value >= HeightBody)
                {
                    throw new ArgumentException(paramName: nameof(value), message: "Высота козырька больше высоты тела!");
                }

                _heightEdge = value;
            }
        }

        public int DiameterBody
        {
            get => _diameterBody;
            set => _diameterBody = value;
        }


        public int LengthVisor
        {
            get => _lengthVisor;
            set => _lengthVisor = value;
        }

        public int HeightVisor
        {
            get => _heightVisor;
            set => _heightVisor = value;
        }

        public int DiameterBoltHeadHoles
        {
            get => _diameterBoltHeadHoles;
            set => _diameterBoltHeadHoles = value;
        }

        public int DepthBoltHeadHoles
        {
            get => _depthBoltHeadHoles;
            set => _depthBoltHeadHoles = value;
        }

        public int DepthBoltThreadHoles
        {
            get => _depthBoltThreadHoles;
            set => _depthBoltThreadHoles = value;
        }

        public int DiameterBoltThreadHoles
        {
            get => _diameterBoltThreadHoles;
            set => _diameterBoltThreadHoles = value;
        }

        public bool CylinderEdge { set; get; }

        /// <summary>
        /// Метод проверки максимальных и минимальных значений
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        private bool ValidateValue(int value, int minValue, int maxValue)
        {
            if (minValue <= value && maxValue >= value)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Перегруженный конструктор с параметрами по умолчанию
        /// </summary>
        public Parameters()
        {
	        DiameterBody = 400;
	        DepthBoltThreadHoles = 65;
	        DepthBoltHeadHoles = 15;
	        CylinderEdge = false;
        }

    }
}