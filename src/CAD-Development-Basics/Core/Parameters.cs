using System;


namespace Core
{
    public class Parameters
    {

        private int _diameterArea;

        private int _heightEdge;

        private int _diameterBody;

        private int _heightBody;

        private int _lengthVisor;

        private int _heightVisor;

        private int _diameterBoltHeadHoles;

        private int _depthBoltHeadHoles;

        private int _depthBoltThreadHoles;

        private int _diameterBoltThreadHoles;

        public int DiameterArea
        {
            get => _diameterArea;
            set
            {
                const int minValue = 600;
                const int maxValue = 1350;
                try
                {
                    ValidateValue(value, minValue, maxValue);
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Введены неправильные параметры!");
                }

                _diameterArea = value;
            }
        }

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

        private bool ValidateValue(int value, int minValue, int maxValue)
        {
            if (minValue <= value || maxValue >= value)
            {
                return true;
            }
            else return false;
        }

        public Parameters()
        {
            DiameterBody = 400;
            DepthBoltThreadHoles = 65;
            DepthBoltHeadHoles = 15;
        }

    }
}