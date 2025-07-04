﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Drawing2D;
using Database_project.Forms;

namespace Database_project
{
    public partial class Form1 : Form
    {
        private List<Image> embeddedImages = new List<Image>();
        private int currentImageIndex = 0;
        private Timer slideshowTimer = new Timer();

        public Form1()
        {
            InitializeComponent(); 

            // Initial centering
            CenterLabel(Hotel);
            this.Resize += Form1_Resize; // Hook up resize event
            
            InitializeSlideshow();

        }
        private void CenterLabel(Label label)
        {
            Hotel.Left = (this.ClientSize.Width - Hotel.Width) / 2;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            Hotel.Left = (this.ClientSize.Width - Hotel.Width) / 2;
        }

        private void InitializeSlideshow()
        {
            // Load embedded images
            LoadEmbeddedImages();

            // Setup timer
            slideshowTimer.Interval = 3000; // 3 seconds
            slideshowTimer.Tick += (s, e) => ShowNextImage();

            if (embeddedImages.Count > 0)
            {
                slideshowTimer.Start();
                DisplayCurrentImage();
            }
        }

        private void LoadEmbeddedImages()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                string[] resourceNames = assembly.GetManifestResourceNames();

                foreach (string resourceName in resourceNames)
                {
                    if (resourceName.EndsWith(".jpeg") ||
                        resourceName.EndsWith(".png") ||
                        resourceName.EndsWith(".bmp") ||
                        resourceName.EndsWith(".jpg"))
                    {
                        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                        {
                            if (stream != null)
                            {
                                embeddedImages.Add(Image.FromStream(stream));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading embedded images: {ex.Message}");
            }
        }

        private void DisplayCurrentImage()
        {
            try
            {
                if (embeddedImages.Count == 0 ||
                    currentImageIndex < 0 ||
                    currentImageIndex >= embeddedImages.Count)
                {
                    return;
                }

                SlideShow.Image?.Dispose();
                SlideShow.Image = new Bitmap(embeddedImages[currentImageIndex]); // Create new copy
                SlideShow.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying image: {ex.Message}");
            }
        }

        private void ShowNextImage()
        {
            if (embeddedImages.Count == 0) return;
            // Safely increment index with wrap-around
            currentImageIndex++;
            if (currentImageIndex >= embeddedImages.Count)
            {
                currentImageIndex = 0; // Reset to first image
            }
            //currentImageIndex = (currentImageIndex + 1) % embeddedImages.Count;
            DisplayCurrentImage();
        }

        private void Reserve_Click(object sender, EventArgs e)
        {
            GuestSearh GP = new GuestSearh(this);  // create an instance of Form2
            GP.Show();               // show Form2
            this.Hide();

/*            RoomSelect rs =new RoomSelect();
            rs.Show();
            this.Hide();*/
        }

        private void StaffRedirect(object sender, EventArgs e)
        {
            ManagerLogin ml = new ManagerLogin(this);
            ml.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckReservation checkReservation = new CheckReservation(this);
            checkReservation.Show();
            this.Hide();
        }
    }
}