using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    internal class Connect
    {
        private String restoConnectionString;
        private SqlConnection con;
        private Connect()
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "resto2";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            this.restoConnectionString = cs.ConnectionString;
            this.con = new SqlConnection(this.restoConnectionString);
        }
        static private Connect singleton = new Connect();
        static internal SqlConnection Connection { get => singleton.con; }
        static internal String ConnectionString { get => singleton.restoConnectionString; }
    }

    internal class DataTables
    {
        private SqlDataAdapter adapterComposants;
        private SqlDataAdapter adapterCommandes;
        private SqlDataAdapter adapterTdc;
        private DataSet ds = new DataSet();

        private void loadTdc()
        {

            adapterTdc = new SqlDataAdapter("SELECT * FROM tdc ORDER BY Type_de_composant", Connect.ConnectionString);
            adapterTdc.Fill(ds, "tdc");

            ds.Tables["tdc"].Columns["Type_de_composant"].AllowDBNull = false;

            ds.Tables["tdc"].PrimaryKey = new DataColumn[1]
                    { ds.Tables["tdc"].Columns["Type_de_composant"]};
            SqlCommandBuilder builder = new SqlCommandBuilder(adapterTdc);
            adapterTdc.UpdateCommand = builder.GetUpdateCommand();
        }

        private void loadComposants()
        {
            adapterComposants = new SqlDataAdapter("SELECT * FROM composants ORDER BY Type_de_Composant, " +
                   "Num_du_Composant", Connect.ConnectionString);
            adapterComposants.Fill(ds, "composants");

            ds.Tables["composants"].Columns["Type_de_Composant"].AllowDBNull = false;
            ds.Tables["composants"].Columns["Num_du_Composant"].AllowDBNull = false;
            ds.Tables["composants"].Columns["Composant"].AllowDBNull = false;
            ds.Tables["composants"].PrimaryKey = new DataColumn[2]
                    { ds.Tables["composants"].Columns["Type_de_Composant"],
                                                ds.Tables["composants"].Columns["Num_du_Composant"]};
            SqlCommandBuilder builder = new SqlCommandBuilder(adapterComposants);
            adapterComposants.UpdateCommand = builder.GetUpdateCommand();

            ForeignKeyConstraint myFK = new ForeignKeyConstraint("MyFK",
            new DataColumn[]{
                ds.Tables["tdc"].Columns["Type_de_composant"],
            },
            new DataColumn[] {
                ds.Tables["composants"].Columns["Type_de_composant"],
            }
            );
            myFK.DeleteRule = Rule.None;
            myFK.UpdateRule = Rule.None;
            ds.Tables["composants"].Constraints.Add(myFK);
        }

        private void loadCommandes()
        {
            adapterCommandes = new SqlDataAdapter(
              "SELECT A.Commande, B.Composant, A.TypeDeComposant, A.NumDuComposant " +
              "FROM commandes  A  " +
              "INNER JOIN composants B " +
              "ON (A.TypeDeComposant=B.Type_de_composant) and (A.NumDuComposant=B.Num_du_composant)" +
              "ORDER BY Commande",
              Connect.ConnectionString);
            adapterCommandes.Fill(ds, "Commandes");

            ds.Tables["Commandes"].Columns["Commande"].AllowDBNull = false;
            ds.Tables["Commandes"].Columns["TypeDeComposant"].AllowDBNull = false;

            ds.Tables["Commandes"].PrimaryKey = new DataColumn[2]
                    { ds.Tables["Commandes"].Columns["Commande"],
                      ds.Tables["Commandes"].Columns["TypeDeComposant"]};
            ForeignKeyConstraint myFK = new ForeignKeyConstraint("MyFK",
            new DataColumn[]{
                ds.Tables["composants"].Columns["Type_de_composant"],
                ds.Tables["composants"].Columns["Num_du_composant"]
            },
            new DataColumn[] {
                ds.Tables["Commandes"].Columns["TypeDeComposant"],
                ds.Tables["Commandes"].Columns["NumDuComposant"],
            }
            );
            myFK.DeleteRule = Rule.None;
            myFK.UpdateRule = Rule.None;
            ds.Tables["Commandes"].Constraints.Add(myFK);
        }

        private DataTables()
        {
            loadTdc();
            loadComposants();
            loadCommandes();

        }

        static private DataTables singleton = new DataTables();

        internal static SqlDataAdapter getAdapterComposants()
        {
            return singleton.adapterComposants;
        }
        internal static SqlDataAdapter getAdapterCommandes()
        {
            return singleton.adapterCommandes;
        }
        internal static SqlDataAdapter getAdapterTdc()
        {
            return singleton.adapterTdc;
        }
        internal static DataSet getDataSet()
        {
            return singleton.ds;
        }
    }
    internal class Tdc
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterTdc();
        private static DataSet ds = DataTables.getDataSet();

        static internal DataTable GetTdc()
        {
            adapter.Fill(ds, "tdc");
            return ds.Tables["tdc"];
        }
        static internal int UpdateTdc()
        {
            if (!ds.Tables["tdc"].HasErrors)
            {
                return adapter.Update(ds.Tables["tdc"]);
            }
            else
            {
                return -1;
            }
        }
    }

    internal class Composants
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterComposants();
        private static DataSet ds = DataTables.getDataSet();

        static internal DataTable GetComposants()
        {
            return ds.Tables["Composants"];
        }
        static internal int UpdateComposants()
        {
            if (!ds.Tables["composants"].HasErrors)
            {
                return adapter.Update(ds.Tables["composants"]);
            }
            else
            {
                return -1;
            }
        }
    }

    internal class Commandes
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterCommandes();
        private static DataSet ds = DataTables.getDataSet();

        static internal DataTable GetCommandes()
        {
            ds.Tables["Commandes"].Clear();
            adapter.Fill(ds, "Commandes");
            return ds.Tables["Commandes"];
        }

        static internal bool SupprimerLignes(List<String[]> list)
        {
            bool updated = false;
            Connect.Connection.Open();
            SqlCommand cmd = new SqlCommand("", Connect.Connection);
            try
            {
                cmd.Transaction = Connect.Connection.BeginTransaction();

                foreach (String[] r in list)
                {
                    cmd.CommandText = "DELETE from commandes where (Commande = " +
                        r[0] +
                        ") and (TypeDeComposant = '" + r[1] +
                        "')";
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
                updated = true;
            }
            catch (Exception)
            {
                updated = false;
            }
            Connect.Connection.Close();
            return updated;
        }
        static internal bool insererLignes(String c, String tdc, String ndc)
        {
            bool updated = false;
            Data.Connect.Connection.Open();

            SqlCommand cmd = Data.Connect.Connection.CreateCommand();
            cmd.CommandText = "INSERT INTO commandes (Commande, TypeDeComposant, NumDuComposant) " +
                    "VALUES ( @c , @tdc , @ndc )";
            cmd.Parameters.Add("@c", SqlDbType.Int);
            cmd.Parameters["@c"].Value = c;
            cmd.Parameters.Add("@tdc", SqlDbType.VarChar, 30);
            cmd.Parameters["@tdc"].Value = tdc;
            cmd.Parameters.Add("@ndc", SqlDbType.Int);
            cmd.Parameters["@ndc"].Value = ndc;
            cmd.ExecuteNonQuery();

            updated = true;

            Data.Connect.Connection.Close();
            return updated;
        }
        static internal bool modifierLignes(String c, String tdc, String ndc)
        {
            bool updated = false;
            Data.Connect.Connection.Open();

            SqlCommand cmd = Data.Connect.Connection.CreateCommand();
            cmd.CommandText = "UPDATE commandes SET NumDuComposant = " + ndc +
                    " WHERE (Commande = " + c + ") AND (TypeDeComposant = '" +
                    tdc + "') ";

            cmd.ExecuteNonQuery();
            updated = true;

            Data.Connect.Connection.Close();
            return updated;
        }

        static internal DataTable TypeDeComposantDisponiblePourUnClient(int n)
        {
            SqlDataAdapter adapter1 = new SqlDataAdapter(
                    "SELECT DISTINCT Type_de_Composant FROM composants " +
                    "WHERE Type_de_Composant NOT IN " +
                    "(SELECT TypeDeComposant FROM commandes WHERE " +
                    " Commande = " + n + ") " +
                    "ORDER BY Type_de_Composant",
                    Connect.ConnectionString);

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Type_de_Composant", typeof(String));
            dt1.Rows.Add(new object[1] { "-- Select one: --" });
            adapter1.Fill(dt1);
            return dt1;
        }

        static internal DataTable ComposantsDunTypeDeComposant(String tdc)
        {
            SqlDataAdapter adapter2 = new SqlDataAdapter(
               "SELECT DISTINCT Num_du_Composant, Composant FROM composants " +
               "WHERE Type_de_Composant =  @typeDeComposant  " +
               "ORDER BY Composant",
               Connect.ConnectionString);

            adapter2.SelectCommand.Parameters.Add("@typeDeComposant", SqlDbType.VarChar, 30);
            adapter2.SelectCommand.Parameters["@typeDeComposant"].Value = tdc;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Num_du_Composant", typeof(int));
            dt2.Columns.Add("Composant", typeof(String));
            dt2.Rows.Add(new object[2] { -1, "-- Select one: --" });
            adapter2.Fill(dt2);
            return dt2;
        }
    }
}
