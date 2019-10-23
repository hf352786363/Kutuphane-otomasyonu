using LibraryAutomation.Business.Abstract;
using LibraryAutomation.Business.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryAutomation.Entity.Concrete;

namespace LibraryAutomationWebFormUI
{
    public partial class BookListDesign : Form
    {
        public BookListDesign()
        {
            InitializeComponent();
            _bookService = InstanceFactory.GetInstance<IBookService>();

        }
        
        private IBookService _bookService;

        string selectedBookNo = Library.SelectedBookNo;

        private void BookListDesign_Load(object sender, EventArgs e)
        {

            string selectedBookName = Library.SelectedBookName;
            string selectedBookAuthor = Library.SelectedBookAuthor;
            string selectedBookInformation = Library.SelectedBookInformation;
            string selectedBookPrintingYear = Library.SelectedBookPrintingYear;
            string selectedBookPageNumber = Library.SelectedBookPageNumber;
            string selectedBookPublisher = Library.SelectedBookPublisher;
            string selectedBookLanguage = Library.SelectedBookLanguage;


            labelKitapDuzenleKitapNoSecilen.Text = selectedBookNo;

            textBoxKitapDuzenleKitapAd.Text = selectedBookName;
            textBoxKitapDuzenleKitapAciklama.Text = selectedBookInformation;

            numericUpDownKitapDuzenleKitapBaskiYil.Text = selectedBookPrintingYear;
            numericUpDownKitapDuzenleKitapSayfaSayi.Text = selectedBookPageNumber;

            comboboxKitapDuzenleKitapYazar.Text = selectedBookAuthor;
            comboBoxKitapDuzenleKitapYayinEvi.Text = selectedBookPublisher;
            comboBoxKitapDuzenleKitapDil.Text = selectedBookLanguage;

        }

        private void ButtonKitapDuzenleIptal_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void ButtonKitapDuzenleKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                _bookService.Update(new Book
                {
                    KitapNo = Convert.ToInt32(selectedBookNo),
                    KitapAd = textBoxKitapDuzenleKitapAd.Text,
                    KitapYazari = comboboxKitapDuzenleKitapYazar.Text,
                    KitapYayinEvi = comboBoxKitapDuzenleKitapYayinEvi.Text,
                    KitapBaskiYil = Convert.ToInt32(numericUpDownKitapDuzenleKitapBaskiYil.Value),
                    KitapSayfaSayi = Convert.ToInt32(numericUpDownKitapDuzenleKitapSayfaSayi.Value),
                    KitapDil = comboBoxKitapDuzenleKitapDil.Text,
                    KitapAciklama = textBoxKitapDuzenleKitapAciklama.Text
                });
                MessageBox.Show("Kitap Güncellendi");
                Hide();
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }

        private void ButtonKitapDuzenleSil_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Kitabı silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                try
                {
                    _bookService.Delete(new Book
                    {
                        KitapNo = Convert.ToInt32(selectedBookNo)
                    });
                    MessageBox.Show("Kitap Silindi");
                    this.Hide();

                }
                catch
                {
                    MessageBox.Show("Bir Hata Oluştu");
                }
            }
        }
    }
}
