namespace CAD_Development_Basics.core
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
            set => _diameterArea = value;
        }

        public int HeightEdge
        {
            get => _heightEdge;
            set => _heightEdge = value;
        }

        public int DiameterBody
        {
            get => _diameterBody;
            set => _diameterBody = value;
        }

        public int HeightBody
        {
            get => _heightBody;
            set => _heightBody = value;
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


    }
}