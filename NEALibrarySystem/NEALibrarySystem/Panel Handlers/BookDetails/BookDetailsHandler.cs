﻿using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;

namespace NEALibrarySystem.PanelHandlers
{
    public class BookDetailsHandler
    {
        private BookDetailsObjects objects;
        private Book bookData;
        public BookDetailsHandler(BookDetailsObjects objs, Book book = null) 
        {
            objects = objs;
            bookData = new Book();
            if (book != null) 
            {
                bookData = book;
                loadBookDetails();
            }
            InitialiseCopyDetails();

        }
        /// <summary>
        /// Loads the book details into the input boxes
        /// </summary>
        public void loadBookDetails()
        {
            //book details
            objects.Title.Text = bookData.GetTitle();
            objects.SeriesTitle.Text = bookData.SeriesTitle;
            objects.SeriesNumber.Text = bookData.SeriesNumber.ToString();
            objects.ISBN.Text = bookData.ISBN;
            objects.MediaType.Text = bookData.GetMediaType();
            objects.Author.Text = bookData.GetAuthor();
            objects.Publisher.Text = bookData.GetPublisher();
            objects.Genres.Text = DataFormatter.ListToString(bookData.GetGenres());
            objects.Themes.Text = DataFormatter.ListToString(bookData.GetThemes());
            objects.Description.Text = bookData.Description;
            objects.Price.Text = bookData.Price.ToString();
            // book copies

        }
        /// <summary>
        /// Opens a form to retrieve new books and adds the inputted values into the bookcopyies list
        /// </summary>
        public void AddBookCopies()
        {
            frmAddBookCopies frmAddBookCopies = new frmAddBookCopies();
            frmAddBookCopies.ShowDialog();
            if (frmAddBookCopies.DialogResult == DialogResult.OK)
            {
                foreach(string barcode in frmAddBookCopies.barcodes)
                {
                    BookCopy temp = new BookCopy()
                    {
                        Barcode = barcode,
                        Status = status.InStock,
                        DueDate = DateTime.Now,
                        OverdueEmailLastSent = DateTime.Now,
                        MemberID = barcode,
                    };
                    bookData.BookCopies.Add(temp);
                }
            }
        }
        public void DeleteBookCopies()
        {

        }
        public void Cancel()
        {

        }
        /// <summary>
        /// Loads book copies into the book copy details listview
        /// </summary>
        private void LoadBookCopies()
        {
            objects.CopyDetails.Items.Clear();
            if (bookData.BookCopies == null)
            {
                foreach (BookCopy bookCopy in bookData.BookCopies)
                {
                    string[] data = new string[3]
                    {
                    bookCopy.Barcode,
                    bookCopy.Status.ToString(),
                    bookCopy.DueDate.ToString()
                    };
                    ListViewItem row = new ListViewItem(data);
                    objects.CopyDetails.Items.Add(row);
                }
            }
        }
        private void InitialiseCopyDetails()
        {
            objects.CopyDetails.View = View.Details;
            objects.CopyDetails.LabelEdit = false;
            objects.CopyDetails.AllowColumnReorder = false;
            objects.CopyDetails.CheckBoxes = true;
            objects.CopyDetails.MultiSelect = true;
            objects.CopyDetails.FullRowSelect = true;
            objects.CopyDetails.GridLines = false;
            objects.CopyDetails.Sorting = SortOrder.None;
            objects.CopyDetails.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            string[] columns = new string[3]
            {
                "Barcode",
                "Status",
                "Due date"
            };
            AddColumns(columns);
        }
        private void AddColumns(string[] columns)
        {
            foreach (string column in columns)
            {
                objects.CopyDetails.Columns.Add(column);
            }
        }
    }
}
