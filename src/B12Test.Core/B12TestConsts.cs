using B12Test.Debugging;

namespace B12Test
{
    public class B12TestConsts
    {
        public const string LocalizationSourceName = "B12Test";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "856f82348f9049e39df580b5d656d30f";
    }
}
