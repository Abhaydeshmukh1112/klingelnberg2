
using BOL;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;

namespace BLL
{
    public class KlingelnBergService
    {
       
        public static string url = @"server=localhost;port=3306;user=root;password=root;database=Kingelnberg";

        public static void insertP(KlingelnBerg p)
        {
            MySqlConnection m=new MySqlConnection(url);
            try
            {
                m.Open();
                string s = "insert into machines values ('"+p.assetName + "','"+p.machineType + "','"+p.seriesNumber+"')";
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                m.Close(); 
            }
        }

        public static void deleteP(int seriesNumber)
        {
            MySqlConnection m=new MySqlConnection(url);
            try
            {
                m.Open();
                string str = "delete from machine where seriesNumber="+ seriesNumber;
                MySqlCommand comd= new MySqlCommand(str,m);
                comd.ExecuteNonQuery();
             }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                m.Close(); 
            }  
        }

        public static List<String> GetAssetNameList()
        {
            MySqlConnection conn = new MySqlConnection(url);
            List<String> list = new List<String>();
            try
            {
                conn.Open();
                String str = "select assetNames from machine";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                MySqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {

                    string assetName = data["assetName"].ToString();
                    list.Add(assetName);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

                conn.Close();

            }
            return list;
        }

        public static List<KlingelnBerg> GetList()
        {
            MySqlConnection conn = new MySqlConnection(url);
            List<KlingelnBerg> list = new List<KlingelnBerg>();
            try
            {
                conn.Open();
                String str = "select * from machine";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                MySqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    
                    string assetName = data["assetName"].ToString();
                    string machineType = data["machineType"].ToString();
                    int seriesNumber = int.Parse(data["seriesNumber"].ToString());
                    list.Add(new KlingelnBerg(assetName, machineType, seriesNumber));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

                conn.Close();

            }
            return list;
        }

        public static List<String> GetLatestMachineTypeList()
        {
            MySqlConnection conn = new MySqlConnection(url);
            List<String> list = new List<String>();
            try
            {
                conn.Open();
                String str = "select machineType from  (select machine_type, MAX(assetName) as latestSeries from machines group by machineTpe having count(distinct assetName) = COUNT(*)) latest_assets";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                MySqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {

                    string assetName = data["assetName"].ToString();
                    list.Add(assetName);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

                conn.Close();

            }
            return list;
        }


        public static void Delete(int id)
        {

            MySqlConnection m = new MySqlConnection(url);
            try
            {
                m.Open();
                String s = "delete from patient where pid=" + id;
                MySqlCommand cmd = new MySqlCommand(s, m);
                Console.WriteLine(s);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { m.Close(); }
        }

    }
}