using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryAutomation.Business.Abstract;
using LibraryAutomation.Business.DependencyResolvers.Ninject;
using LibraryAutomation.Entity.Concrete;

namespace LibraryAutomationWebFormUI
{
    public partial class MemberList : Form
    {
        public MemberList()
        {
            InitializeComponent();
            _memberService = InstanceFactory.GetInstance<IMemberService>();
        }

        private IMemberService _memberService;

        private string selectedMemberNo = Library.SelectedMemberNo;
        private void MemberList_Load(object sender, EventArgs e)
        {
            string selectedMemberName = Library.SelectedMemberName;
            string selectedMemberLastName = Library.SelectedMemberLastName;
            string selectedMemberPhoneNumber = Library.SelectedMemberPhoneNumber;
            string selectedMemberEmail = Library.SelectedMemberEmail;
            string selectedMemberAddress = Library.SelectedMemberAddress;


            labelUyeListeleDuzenleSecilen.Text = selectedMemberNo;
            textBoxUyeListeleDuzenleAd.Text = selectedMemberName;
            textBoxUyeListeleDuzenleSoyad.Text = selectedMemberLastName;
            maskedTextBoxUyeListeleDuzenleTelefon.Text = selectedMemberPhoneNumber;
            textBoxUyeListeleDuzenleEposta.Text = selectedMemberEmail;
            textBoxUyeListeleDuzenleAdres.Text = selectedMemberAddress;
        }

        private void ButtonUyeListeleDuzenleKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                _memberService.Update(new Member
                {
                    UyeNo = Convert.ToInt32(selectedMemberNo),
                    UyeAd = textBoxUyeListeleDuzenleAd.Text,
                    UyeSoyad = textBoxUyeListeleDuzenleEposta.Text,
                    UyeTelefon = maskedTextBoxUyeListeleDuzenleTelefon.Text,
                    UyeEposta = textBoxUyeListeleDuzenleEposta.Text,
                    UyeAdres = textBoxUyeListeleDuzenleAdres.Text
                });
                MessageBox.Show("Üye Güncellendi");
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }

        private void ButtonUyeListeleDuzenleIptal_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ButtonUyeListeleDuzenleSil_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Üyeyi silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                try
                {
                    _memberService.Delete(new Member
                    {
                        UyeNo = Convert.ToInt32(selectedMemberNo)
                    });
                    MessageBox.Show("Üye Silindi");
                    this.Hide();
                }
                catch (Exception)
                {
                    MessageBox.Show("Bir Hata Oluştu");
                }
            }
        }
    }
}
