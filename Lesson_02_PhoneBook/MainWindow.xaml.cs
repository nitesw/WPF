using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Lesson_02_PhoneBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts = new List<Contact>();
        public MainWindow()
        {
            InitializeComponent();
            LoadFromFile();
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            ContactListBox.ItemsSource = null;
            ContactListBox.ItemsSource = contacts;
        }
        private void SaveToFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Contact>));
            try
            {
                using(Stream stream = File.Create("Contacts.xml"))
                {
                    xmlSerializer.Serialize(stream, contacts);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void LoadFromFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Contact>));
            try
            {
                List<Contact> newContacts = null;
                using(Stream stream = File.OpenRead("Contacts.xml"))
                {
                    newContacts = (List<Contact>)xmlSerializer.Deserialize(stream);
                }
                contacts = newContacts;
                UpdateListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact();
            NewContact newContactWindow = new NewContact(contact);
            if(newContactWindow.ShowDialog() == true)
            {
                contacts.Add(new Contact(contact.FullName, contact.PhoneNumber, contact.EmailAddress));
            }

            UpdateListBox();
            SaveToFile();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ContactListBox.SelectedIndex == -1)
            {
                MessageBox.Show("There is no selected contact to delete!", "Warning", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }
            Contact contact = (Contact)ContactListBox.SelectedItem;
            NewContact newContactWindow = new NewContact(contact);

            if(newContactWindow.ShowDialog() == true)
            {
                int selectedIndex = ContactListBox.SelectedIndex;
                contacts[selectedIndex] = newContactWindow.contact;

                UpdateListBox();
                SaveToFile();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ContactListBox.SelectedIndex == -1)
            {
                MessageBox.Show("There is no selected contact to delete!", "Warning", MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return;
            }
            contacts.Remove((Contact)ContactListBox.SelectedItem);

            UpdateListBox();
            SaveToFile();
        }
    }
}