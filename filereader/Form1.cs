using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Need to add in this using so we have access the Input/Output library for reading files
using System.IO;

namespace filereader
{
    public partial class Form1 : Form
    {
        // Default Constructor
        // This is basically the first thing that is called.
        // The InitializeComponent() method is created by Visual Studio
        // and executes all the code they write for you to get the basic empty
        // window to show up.
        public Form1()
        {
            InitializeComponent();

            // Set up any custom event handling.
            InitializeEventHandlers();

            // Read in all the files from "folderPath"
            this.files = LoadFiles();  

            // Create a StatusBar to display the path of the file.
            // This is in here as an example of creating and adding controls
            // through code instead of through the visual designer.
            CreateStatusBar();
        }

        // PRIVATE

        // Save the path of the folder so we only have to create it once.
        private string folderPath = Environment.CurrentDirectory + "\\docs";
        // Create an object that will allow us to manipulate the docs directory.
        private DirectoryInfo docsInfo;
        // Create a enumerable list of FileInfo objects, to hold the files found in docs.
        private IEnumerable<FileInfo> files;
        // Create a StatusBar object to programmatically add to form.
        private StatusBar statusBar;

        // METHODS

        /// <summary>
        /// Method used to set up any special event handlers that we want to use in this program.
        /// </summary>
        private void InitializeEventHandlers()
        {
            // We want to wait until the UI thread has finished drawing the
            // controls on the screen before we populate the list with the
            // file names.  Normally, any intensive IO or anything else that might
            // hold up the UI, would be done in another thread.  That is overkill
            // for this example.  What we will do is defer the loading of the list
            // until the "Form1.Shown()" event is fired.  That way we know that the 
            // form is done drawing and showing.
            // The below is called Event Handling.  See this for info on Events:
            // http://msdn.microsoft.com/en-us/library/ms366768%28v=vs.110%29.aspx
            // I am also using a coding convenience called a "lambda expression" which
            // helps write more concise code.  Scroll down the the page of the above link
            // for info on that.
            // The gist is, when the Form1.Shown event fires, then also call my PopulateListBox method.
            this.Shown += (s, e) =>
                {
                    // Once the form completed drawing, populate the listbox.
                    PopulateListBox(this.files, this.listBoxDocuments);
                };

            // We want to show the contents of a text file when it is clicked on in the listbox.
            // The contents should be displayed in the RichTextBox we added.
            this.listBoxDocuments.SelectedValueChanged += (s, e) =>
                {
                    // First, lets get the FileInfo object that was clicked and
                    // save it to a local FileInfo variable.
                    FileInfo clickedFile = (FileInfo)this.listBoxDocuments.SelectedItem;

                    // When an item is selected in the listbox, this event will fire.
                    DisplayFileContents(clickedFile, this.rtbDocViewer);

                    // We want to update the StatusBar with this file's path.
                    this.statusBar.Text = clickedFile.FullName;
                };
        }

        /// <summary>
        /// Create the StatusBar control and add it to the Form1.
        /// </summary>
        private void CreateStatusBar()
        {
            // Create the new StatusBar
            this.statusBar = new StatusBar();       

            // Add the StatusBar to the Controls Collection for Form1.
            // This is the kind of thing that the InitializeComponent()
            // method is doing.
            this.Controls.Add(statusBar);

            // NOTE: we are not doing any layout for the Form1.  The StatusBar
            // is always placed at the bottom of a form.  You might have to resize
            // the form when running it to see the full StatusBar.  Layout and all of
            // the UI stuff is a whole other can of worms.
        }

        /// <summary>
        /// Get all the files contained in the docs folder.
        /// <note>The way the file IO is handled in this method is just
        /// one of many ways.  This is not the only way to go about this task.</note>
        /// </summary>
        private IEnumerable<FileInfo> LoadFiles()
        {
            // Create a local variable to hold the files read from docs directory.
            IEnumerable<FileInfo> retval = null;

            // Check that the docs folder exists.
            if (Directory.Exists(folderPath))
            {
                // If the docs folder exists then get all of the files.
                // First, create the new DirectoryInfo object, passing it the path to docs.
                docsInfo = new DirectoryInfo(folderPath);
                // Second, enumerate that directory and get the files.  Save them in the
                // retval (return value) variable.
                retval = docsInfo.EnumerateFiles();                
            }
            else
            {
                // If we can't find the docs directory, show an error.
                this.listBoxDocuments.Items.Add("ERROR: directory " + folderPath + " does not exist.");
            }

            // Return the list of files.
            return retval;
        }

        /// <summary>
        /// Populate a ListBox with an IEnumerable collection filled with FileInfo objects.
        /// </summary>
        /// <param name="files">
        /// A collection of FileInfo objects that can be enumerated over.
        /// </param>
        /// <param name="listBox">
        /// A ListBox object.  In this program, it is the ListBox you created.
        /// </param>
        private void PopulateListBox(IEnumerable<FileInfo> files, ListBox listBox)
        {
            // If our list is empty, don't do anything.
            if (files.Count() < 1)
            {
                return;
            }

            // Loop over the files collection and for each item, add
            // it as an item in the ListBox.
            foreach (FileInfo fi in files)
            {
                listBox.Items.Add(fi);
            }
        }

        /// <summary>
        /// Put the contents of a text file into the RichTextBox.
        /// </summary>
        /// <param name="file">
        /// A FileInfo object that is the file the user wants to see the
        /// contents of.
        /// </param>
        /// <param name="rtb">
        /// The RichTextBox to display the contents of the file into.
        /// </param>
        private void DisplayFileContents(FileInfo file, RichTextBox rtb)
        {
            // Make sure to clear the contents of the RichTextBox before filling it.
            rtb.Clear();

            // Open a streamreader and read the file contents. 
            using (StreamReader sr = file.OpenText())
            {
                // Create a string variable to hold each line of text read in.
                string s = "";
                // While the line of text read in is not equal to NULL, keep reading lines.
                while ((s = sr.ReadLine()) != null)
                {
                    // If we read a line of text then write it to the RichTextBox.
                    rtb.AppendText(s);
                }
            }            
        }
    }
}
