using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactManager.Models;
using ContactManager.Services;

namespace ContactManager
{
    public partial class Form1 : Form
    {
        private ContactService _contactService;
        public Form1()
        {
            InitializeComponent();            
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _contactService = new ContactService();
            await _contactService.InitializeDatabaseAsync();            
            await LoadContactsAsync();
        }

        private async Task LoadContactsAsync()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            var contacts = await _contactService.GetContactsAsync();
            dataGridView1.DataSource = contacts;

            stopwatch.Stop();
            MessageBox.Show($"Tiempo total al cargar datos: {stopwatch.ElapsedMilliseconds} ms");
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            // Validar el teléfono
            string phone = txtPhone.Text;
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{10}$"))
            {
                MessageBox.Show("El número de teléfono debe contener exactamente 10 dígitos numéricos.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            var contact = new Contact
            {
                name = txtName.Text,
                email = txtEmail.Text,
                phone = txtPhone.Text
            };
            await _contactService.AddContactAsync(contact);
            var contacts = await _contactService.GetContactsAsync();
            dataGridView1.DataSource = contacts; // Actualizar la UI
            EmptyFields();

            stopwatch.Stop();
            MessageBox.Show($"Tiempo total: {stopwatch.ElapsedMilliseconds} ms");
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este contacto?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    var contact = dataGridView1.SelectedRows[0];
                    int conctactId = (int)contact.Cells["id"].Value;
                    await _contactService.DeleteContact(conctactId);
                    await LoadContactsAsync();
                } else
                {
                    MessageBox.Show("Operación cancelada");
                    return;
                }
            }
        }

        private void EmptyFields()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }

        
    }
}
