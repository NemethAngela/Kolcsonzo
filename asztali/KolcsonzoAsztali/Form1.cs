using MySqlConnector;

namespace KolcsonzoAsztali
{
    public partial class Form1 : Form
    {
        const string connectionString = "server=localhost;user=root;password=titok;database=kolcsonzo";

        public Form1()
        {
            InitializeComponent();

            FillListBoxNevek();
        }

        private void FillListBoxNevek()
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT id, nev FROM kolcsonzok ORDER BY nev";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            using MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nev = reader.GetString(1);

                listBoxNevek.Items.Add(new Kolcsonzok { Id = id, Nev = nev });
            }

            connection.Close();
        }

        private void listBoxNevek_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxKonyvek.Items.Clear();
            buttonVisszahozva.Enabled = false;

            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT id, kolcsonzokId, CONCAT(cim, ' - ', iro, ' (', mufaj, ')') AS info FROM kolcsonzesek WHERE kolcsonzokId = @kolcsonzokId";
            using MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@kolcsonzokId", ((Kolcsonzok)listBoxNevek.SelectedItem).Id.ToString());
            using MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int kolcsonzokId = reader.GetInt32(1);
                string info = reader.GetString(2);

                listBoxKonyvek.Items.Add(new Kolcsonzesek { Id = id, Info = info });
            }

            connection.Close();
        }

        private void listBoxKonyvek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxKonyvek.SelectedItems.Count > 0)
            {
                buttonVisszahozva.Enabled = true;
            }
            else
            {
                buttonVisszahozva.Enabled = false;
            }
        }

        private void buttonBezar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonVisszahozva_Click(object sender, EventArgs e)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "DELETE FROM kolcsonzesek WHERE id = @id";
            using MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", ((Kolcsonzesek)listBoxKonyvek.SelectedItem).Id);
            cmd.ExecuteNonQuery();

            connection.Close();

            listBoxKonyvek.Items.Remove(listBoxKonyvek.SelectedItem);
        }
    }
}