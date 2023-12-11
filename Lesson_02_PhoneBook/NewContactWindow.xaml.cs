using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lesson_02_PhoneBook
{
    /// <summary>
    /// Interaction logic for NewContact.xaml
    /// </summary>
    public partial class NewContact : Window
    {
        public Contact contact { get; set; }

        public NewContact()
        {
            InitializeComponent();
            contact = new Contact();
        }
        public NewContact(Contact c)
        {
            InitializeComponent();
            contact = c;

            FullNameTextBox.Text = contact.FullName;
            PhoneTextBox.Text = contact.PhoneNumber;
            EmailTextBox.Text = contact.EmailAddress;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(FullNameTextBox.Text) || string.IsNullOrWhiteSpace(PhoneTextBox.Text) 
                || string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Fullfill all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            string phonePattern = @"^\+380\d{2}\d{7}$";
            if(!Regex.IsMatch(EmailTextBox.Text, emailPattern) || !Regex.IsMatch(PhoneTextBox.Text, phonePattern))
            {
                MessageBox.Show("Enter proper email or phone number!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            contact.FullName = FullNameTextBox.Text;
            contact.PhoneNumber = PhoneTextBox.Text;
            contact.EmailAddress = EmailTextBox.Text;

            DialogResult = true;

            Close();
        }
    }
}
