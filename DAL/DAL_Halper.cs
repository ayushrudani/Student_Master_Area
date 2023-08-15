namespace Student_Master_Areas.DAL
{
    public class DAL_Halper
    {
        public static string myConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("myConnectionString");
    }
}
