namespace Common
{
    public static class Parameters
    {
        public const string AppContext = "AppContext";

        #region App.parameters.config
        public static string Environment { get; set; }
        public static string ProjectName { get; set; }
        public static string ProjectVersion { get; set; }
        public static int SalesCommission { get; set; }
        #endregion
    }
}
