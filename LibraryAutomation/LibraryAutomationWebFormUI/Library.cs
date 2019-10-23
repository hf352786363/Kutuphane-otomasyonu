using LibraryAutomation.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryAutomation.Business.Abstract;
using LibraryAutomation.Business.DependencyResolvers.Ninject;
using LibraryAutomation.Entity.Concrete;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Ninject.Infrastructure.Language;

namespace LibraryAutomationWebFormUI
{
    public partial class Library : Form
    {
        public Library()
        {
            InitializeComponent();
            _bookService = InstanceFactory.GetInstance<IBookService>();
            _relicService = InstanceFactory.GetInstance<IRelicService>();
            _memberService = InstanceFactory.GetInstance<IMemberService>();
        }

        private IBookService _bookService;
        private IMemberService _memberService;
        private IRelicService _relicService;

        SqlConnection _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Library;");

        private void Library_Load(object sender, EventArgs e)
        {
            NonVisible();
        }

        private void NonVisible()
        {
            groupBoxKitapEkle.Visible = false;
            groupBoxKitapListele.Visible = false;
            groupBoxUyeEkle.Visible = false;
            groupBoxUyeListele.Visible = false;
            groupBoxEmanetVer.Visible = false;
            groupBoxEmanettekiKitaplarListele.Visible = false;
        }

        public void LoadMembers()
        {
            dataGridViewUyeListele.DataSource = _memberService.GetAll();
        }

        public void LoadRelics()
        {
            dataGridViewEmanetleriListele.DataSource = _relicService.GetAll();
        }

        public void LoadBooks()
        {
            dataGridViewKitapListele.DataSource = _bookService.GetAll();
        }

        private void ButtonKitapEkle_Click_1(object sender, EventArgs e)
        {
            try
            {
                _bookService.Add(new Book
                {
                    KitapAciklama = textBoxKitapEkleAciklama.Text,
                    KitapAd = textBoxKitapEkleAd.Text,
                    KitapBaskiYil = Convert.ToInt32(numericUpDownKitapEkleBaskiYil.Text),
                    KitapDil = comboBoxKitapEkleDil.Text,
                    KitapSayfaSayi = Convert.ToInt32(numericUpDownKitapEkleSayfaSayi.Text),
                    KitapYayinEvi = comboBoxKitapEkleYayinEvi.Text,
                    KitapYazari = comboBoxKitapEkleYazar.Text,
                });

                MessageBox.Show("Kitap Başarıyla Eklendi");
                LoadBooks();
                textBoxKitapEkleAd.Text = null;
                numericUpDownKitapEkleBaskiYil.Value = 2015;
                numericUpDownKitapEkleSayfaSayi.Value = 300;
                comboBoxKitapEkleDil.Text = "Türkçe";
                comboBoxKitapEkleYayinEvi.Text = "Bilinmiyor";
                textBoxKitapEkleAciklama.Text = null;


            }
            catch (Exception)
            {

                MessageBox.Show("Bir Hata Oluştu");
            }
        }

        private void KitapEkleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NonVisible();
            groupBoxKitapEkle.Visible = true;
            NonVisibleButtons();
            #region ComboboxDoldur
            //comboBoxKitapEkleDil.Items.Clear();
            //comboBoxKitapEkleYayinEvi.Items.Clear();
            //comboBoxKitapEkleYazar.Items.Clear();

            //var cbxAddBooksFill = _bookService.GetAll().ToList();
            //foreach (var item in cbxAddBooksFill)
            //{
            //    comboBoxKitapEkleDil.Items.Add(item.KitapDil);
            //}

            //foreach (var item in cbxAddBooksFill)
            //{
            //    comboBoxKitapEkleYayinEvi.Items.Add(item.KitapYayinEvi);
            //}

            //foreach (var item in cbxAddBooksFill)
            //{
            //    comboBoxKitapEkleYazar.Items.Add(item.KitapYazari);
            //}

            #endregion
            BookTableComboboxFill();
        }

        private void NonVisibleButtons()
        {
            buttonGirisKitapEkle.Visible = false;
            buttonGirisKitapListele.Visible = false;
            buttonGirisEmanetEkle.Visible = false;
            buttonGirisEmanetListele.Visible = false;
            buttonGirisUyeEkle.Visible = false;
            buttonGirisUyeListele.Visible = false;
        }


        private void BookTableComboboxFill()
        {
            comboBoxKitapEkleDil.DataSource =
                _bookService.GetBookLanguage().ToList(); //comboboxa aynı verinin sadece bir kere gelmesini sağlayan linq kodu
            comboBoxKitapEkleDil.DisplayMember = "KitapDil";

            comboBoxKitapEkleYayinEvi.DataSource =
                _bookService.GetBookPublisher().ToList(); //comboboxa aynı verinin sadece bir kere gelmesini sağlayan linq kodu
            comboBoxKitapEkleYayinEvi.DisplayMember = "KitapYayinEvi";

            comboBoxKitapEkleYazar.DataSource =
                _bookService.GetBookAuthor().ToList(); //comboboxa aynı verinin sadece bir kere gelmesini sağlayan linq kodu
            comboBoxKitapEkleYazar.DisplayMember = "KitapYazari";
        }

        public void KitapListeleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NonVisible();
            groupBoxKitapListele.Visible = true;
            NonVisibleButtons();
            LoadBooks();
        }

        public static string SelectedBookNo;
        public static string SelectedBookName;
        public static string SelectedBookAuthor;
        public static string SelectedBookInformation;
        public static string SelectedBookPrintingYear;
        public static string SelectedBookPageNumber;
        public static string SelectedBookPublisher;
        public static string SelectedBookLanguage;
        private void DataGridViewKitapListele_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            var row = dataGridViewKitapListele.CurrentRow;

            if (row != null)
            {
                SelectedBookNo = row.Cells[0].Value.ToString();
            }

            if (row != null)
            {
                SelectedBookName = row.Cells[1].Value.ToString();
            }

            if (row != null)
            {
                SelectedBookAuthor = row.Cells[2].Value.ToString();
            }

            if (row != null)
            {
                SelectedBookInformation = row.Cells[7].Value.ToString();
            }

            if (row != null)
            {
                SelectedBookPrintingYear = row.Cells[3].Value.ToString();
            }

            if (row != null)
            {
                SelectedBookPageNumber = row.Cells[4].Value.ToString();
            }

            if (row != null)
            {
                SelectedBookLanguage = row.Cells[5].Value.ToString();
            }

            if (row != null)
            {
                SelectedBookPublisher = row.Cells[6].Value.ToString();
            }

            BookListDesign bookListDesign = new BookListDesign();
            bookListDesign.ShowDialog();
            LoadBooks();
        }

        private void ButtonUyeEkle_Click_1(object sender, EventArgs e)
        {
            try
            {
                _memberService.Add(new Member
                {
                    UyeAd = textBoxUyeEkleAd.Text,
                    UyeSoyad = textBoxUyeEkleSoyad.Text,
                    UyeTelefon = maskedTextBoxUyeEkleTelefon.Text,
                    UyeAdres = textBoxUyeEkleAdres.Text,
                    UyeEposta = textBoxUyeEkleEposta.Text
                });
                MessageBox.Show("Üye Başarıyla Eklendi");
                LoadMembers();

                textBoxUyeEkleAd.Text = "";
                textBoxUyeEkleSoyad.Text = "";
                maskedTextBoxUyeEkleTelefon.Text = "";
                textBoxUyeEkleEposta.Text = "";
                textBoxUyeEkleAdres.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }

        private void ÜyeEkleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NonVisible();
            groupBoxUyeEkle.Visible = true;
            NonVisibleButtons();
        }

        private void ÜyeListeleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NonVisible();
            groupBoxUyeListele.Visible = true;
            NonVisibleButtons();
            LoadMembers();
        }

        public static string SelectedMemberNo;
        public static string SelectedMemberName;
        public static string SelectedMemberLastName;
        public static string SelectedMemberPhoneNumber;
        public static string SelectedMemberEmail;
        public static string SelectedMemberAddress;
        private void DataGridViewUyeListele_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            var row = dataGridViewUyeListele.CurrentRow;

            if (row != null)
            {
                SelectedMemberNo = row.Cells[0].Value.ToString();
            }

            if (row != null)
            {
                SelectedMemberName = row.Cells[1].Value.ToString();
            }

            if (row != null)
            {
                SelectedMemberLastName = row.Cells[2].Value.ToString();
            }

            if (row != null)
            {
                SelectedMemberPhoneNumber = row.Cells[3].Value.ToString();
            }

            if (row != null)
            {
                SelectedMemberEmail = row.Cells[4].Value.ToString();
            }

            if (row != null)
            {
                SelectedMemberAddress = row.Cells[5].Value.ToString();
            }

            MemberList memberList = new MemberList();
            memberList.ShowDialog();
            LoadMembers();
        }

        private void ButtonEmanetVer_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime relicGiveTime = dateTimePickerEmanetVerEmanetVermeTarih.Value;
                DateTime relicTakeTime = dateTimePickerEmanetVerEmanetAlmaTarih.Value;
                DateTime presentTime = DateTime.Now;
                int result = DateTime.Compare(relicGiveTime, relicTakeTime);

                if (result == 1)
                {
                    MessageBox.Show("Emanet Geri Alma Tarihi Emanet Vermeden Önce Olamaz");
                }
                else
                {
                    _relicService.Add(new Relic
                    {
                        UyeNo = Convert.ToInt32(comboBoxEmanetVerUyeAd.SelectedValue.ToString()),
                        KitapNo = Convert.ToInt32(comboBoxEmanetVerKitapAd.SelectedValue.ToString()),
                        EmanetVermeTarih = Convert.ToDateTime(dateTimePickerEmanetVerEmanetVermeTarih.Value),
                        EmanetGeriAlmaTarih = Convert.ToDateTime(dateTimePickerEmanetVerEmanetAlmaTarih.Value),
                        EmanetIslemTarih = Convert.ToDateTime(presentTime),
                        EmanetNot = textBoxEmanetVerNot.Text
                    });
                    MessageBox.Show("Emanet Kaydedildi");
                    LoadRelics();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }

        private void EmanetVerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NonVisible();
            NonVisible();
            groupBoxEmanetVer.Visible = true;
            dateTimePickerEmanetVerEmanetVermeTarih.Value = DateTime.Today;
            dateTimePickerEmanetVerEmanetAlmaTarih.Value = DateTime.Today.AddDays(1);

            #region ComboboxDoldur

            //comboBoxEmanetVerKitapAd.Items.Clear();
            //comboBoxEmanetVerUyeAd.Items.Clear();

            //var cbxAddBooksToRelic = _bookService.GetAll().ToList();
            //foreach (var item in cbxAddBooksToRelic)
            //{
            //    comboBoxEmanetVerKitapAd.Items.Add(item.KitapAd);
            //}

            //var cbxAddMembersToRelic = _memberService.GetAll().ToList();
            //foreach (var item in cbxAddMembersToRelic)
            //{
            //    comboBoxEmanetVerUyeAd.Items.Add(item.UyeAd);
            //}

            #endregion
            #region ComboboxMemberListAdonet         
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT UyeNo,(UyeAd + ' ' + UyeSoyad + ' TEL: ' + UyeTelefon ) AS UyeBilgi FROM Members ORDER BY UyeAd ASC", _connection);
            DataTable cbxMemberName = new DataTable();
            adapter.Fill(cbxMemberName);

            comboBoxEmanetVerUyeAd.DataSource = cbxMemberName;
            comboBoxEmanetVerUyeAd.DisplayMember = "UyeBilgi";// Combobox ta görünecek olan hücre
            comboBoxEmanetVerUyeAd.ValueMember = "UyeNo"; // Arka Planda tutulacak olan hücre
            #endregion
            #region ComboboxBookListAdonet
            SqlDataAdapter relicBookListAdapter = new SqlDataAdapter("SELECT KitapNo,(KitapAd + ' - ' + KitapYazari  + ' - ' + KitapYayinEvi ) AS KitapBilgi FROM Books ORDER BY KitapAd ASC", _connection);
            DataTable cbxBookName = new DataTable();
            relicBookListAdapter.Fill(cbxBookName);

            comboBoxEmanetVerKitapAd.DataSource = cbxBookName;
            comboBoxEmanetVerKitapAd.DisplayMember = "KitapBilgi";// Combobox ta görünecek olan hücre
            comboBoxEmanetVerKitapAd.ValueMember = "KitapNo"; // Arka Planda tutulacak olan hücre
            #endregion

        }

        private void EmanettekiKitaplarıListeleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NonVisible();
            groupBoxEmanettekiKitaplarListele.Visible = true;
            NonVisibleButtons();
            LoadRelics();

            var relic = _relicService.GetAll().ToList();

            for (int i = 0; i < dataGridViewEmanetleriListele.Rows.Count; i++)
            {
                if (relic[i].EmanetGeriAlmaTarih == DateTime.Today)
                {
                    dataGridViewEmanetleriListele.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        public static string SelectedRelicNo;
        public static string SelectedRelicMemberNo;
        public static string SelectedRelicBookNo;
        public static string SelectedRelicGiveTime;
        public static string SelectedRelicTakeTime;
        public static string SelectedRelicProcessTime;
        public static string SelectedRelicNote;
        private void DataGridViewEmanetleriListele_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            var row = dataGridViewEmanetleriListele.CurrentRow;

            if (row != null)
            {
                SelectedRelicNo = row.Cells[0].Value.ToString();
            }

            if (row != null)
            {
                SelectedRelicMemberNo = row.Cells[1].Value.ToString();
            }

            if (row != null)
            {
                SelectedRelicBookNo = row.Cells[2].Value.ToString();
            }

            if (row != null)
            {
                SelectedRelicGiveTime = row.Cells[3].Value.ToString();
            }

            if (row != null)
            {
                SelectedRelicTakeTime = row.Cells[4].Value.ToString();
            }

            if (row != null)
            {
                SelectedRelicProcessTime = row.Cells[5].Value.ToString();
            }

            if (row != null)
            {
                SelectedRelicNote = row.Cells[6].Value.ToString();
            }

            RelicList relicList = new RelicList();
            relicList.ShowDialog();
            LoadRelics();
        }

        private void HakkındaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("HFSoftWare");
        }
    }
}
