using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace BusinessLayer
{
    internal class Commandes
    {
        static internal DataTable TypeDeComposantDisponiblePourUnClient(int n)
        {
            DataTable dt = Data.Commandes.TypeDeComposantDisponiblePourUnClient(n);
            DataRow[] temp = dt.Select("Type_de_Composant='plat principal'");
           
            DataTable result;


            if (temp.Length > 0)
            {


                result = new DataTable();
                result.Columns.Add("Type_de_Composant", typeof(String));
                result.Rows.Add(new object[1] { "-- Select one: --" });
                result.Rows.Add(new object[1] { "plat principal" });
            }
            else
            {
                DataRow[] temp2 = dt.Select("Type_de_Composant='boisson'");


                if (temp2.Length > 0)
                {

                    result = new DataTable();
                    result.Columns.Add("Type_de_Composant", typeof(String));
                    result.Rows.Add(new object[1] { "-- Select one: --" });
                    result.Rows.Add(new object[1] { "boisson" });

                }

                else
                {
                    result = dt;
                }
            }
                
            return result;

        }

    }
}
