namespace LR3.Calculation
{
    public static class CalculationConstants
    {
        public enum ArgName
        {
            FIRST,
            SECOND
        };

        public enum Path
        {
            SUM,

            SUBTRACT,

            MULTIPLY,

            DIVIDE,

            POW,
        }

        public static readonly IDictionary<ArgName, string> ArgNames = new Dictionary<ArgName, string>() {
            { ArgName.FIRST, "x" },
            { ArgName.SECOND, "y" }
        };

        public static readonly IDictionary<Path, string> Paths = new Dictionary<Path, string> {
            { Path.SUM, "/sum" },
            { Path.SUBTRACT, "/subtract" },
            { Path.MULTIPLY, "/multiply" },
            { Path.DIVIDE, "/divide" },
            { Path.POW, "/pow" },
        };


    }
}

//        public enum ArgNames
//{
//    FIRST = "x"

//            SECOND = "y";
//};

//public enum Path
//{
//            public const string SUM = "/sum";

//public const string SUBTRACT = "/subtract";

//public const string MULTIPLY = "/multiply";

//public const string DIVIDE = "/divide";

//public const string POW = "/pow";
//        }
