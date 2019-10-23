using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryAutomation.Business.Abstract;
using LibraryAutomation.Business.DependencyResolvers.Ninject;
using LibraryAutomation.DataAccess.Concrete.EntityFramework;
using LibraryAutomation.Entity.Concrete;

namespace LibraryAutomationWebFormUI
{
    public partial class RelicList : Form
    {
        public RelicList()
        {
            InitializeComponent();
        }
        
        SqlConnection _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Library;");

        private void RelicList_Load(object sender, EventArgs e)
        {
            #region RelicsDataShowWithAdonet

            _connection.Open();
            SqlCommand command=new SqlCommand("SELECT * FROM Relics INNER JOIN Members ON Relics.UyeNo = Members.UyeNo INNER JOIN Books ON Books.KitapNo=Relics.KitapNo WHERE Relics.EmanetNo =@selectedRelicNo",_connection);
            command.Parameters.Add("@selectedRelicNo", SqlDbType.Int).Value = Library.SelectedRelicNo.ToString();

            SqlDataReader results = command.ExecuteReader();
            while (results.Read())
            {
                labelEmanetNoVeri.Text = results["EmanetNo"].ToString();
                labelEmanetVermeTarihVeri.Text = results["EmanetVermeTarih"].ToString();
                labelEmanetAlmaVeri.Text = results["EmanetGeriAlmaTarih"].ToString();
                labelEmanetIslemTarihVeri.Text = results["EmanetIslemTarih"].ToString();
                labelEmanetNotVeri.Text = results["EmanetNot"].ToString();

                labelUyeNoVeri.Text = results["UyeNo"].ToString();
                labelUyeAdVeri.Text = results["UyeAd"].ToString();
                labelUyeSoyadVeri.Text = results["UyeSoyad"].ToString();
                labelUyeTelefonVeri.Text = results["UyeTelefon"].ToString();
                labelUyeEpostaVeri.Text = results["UyeEposta"].ToString();
                labelUyeAdresVeri.Text = results["UyeAdres"].ToString();

                labelKitapNoVeri.Text = results["KitapNo"].ToString();
                labelKitapAdVeri.Text = results["KitapAd"].ToString();
                labelKitapYazarVeri.Text = results["KitapYazari"].ToString();
                labelKitapBaskiYilVeri.Text = results["KitapBaskiYil"].ToString();
                labelKitapSayfaSayiVeri.Text = results["KitapSayfaSayi"].ToString();
                labelKitapDilVeri.Text = results["KitapDil"].ToString();
                labelKitapYayinEviVeri.Text = results["KitapYayinEvi"].ToString();
                labelKitapAciklamaVeri.Text = results["KitapAciklama"].ToString();
            }
            _connection.Close();

            #endregion
        }

        private void ButtonKitapTeslimAlindi_Click(object sender, EventArgs e)
        {
            #region RelicsDataUpdateWithAdonet

            var result = MessageBox.Show("Kitabın Alındığını teyit ediyormusunuz?", "Uyarı", MessageBoxButtons.OKCancel);
            if (result==DialogResult.OK)
            {
                try
                {
                    _connection.Open();
                    SqlCommand RelicTaken = new SqlCommand("UPDATE Relics SET EmanetTeslimEdildi='Evet' WHERE EmanetNo = @secilen   ", _connection);
                    RelicTaken.Parameters.Add("@secilen", SqlDbType.Int).Value = Library.SelectedRelicNo;
                    RelicTaken.ExecuteNonQuery();
                    _connection.Close();
                    MessageBox.Show("Kitap Teslim Alındı");
                    this.Hide();
                }
                catch (Exception)
                {

                    MessageBox.Show("Bir hata oluştu");
                }
            }

            #endregion
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
