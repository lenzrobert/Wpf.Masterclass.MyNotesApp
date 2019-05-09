using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Wpf.Masterclass.MyNotesApp.View
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        public NotesWindow()
        {
            InitializeComponent();
        }

        private void BtnSpeech_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnBold_Click(object sender, RoutedEventArgs e)
        {
            RichTxtBxContent.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
        }

        private void RichTxtBxContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            int charactersCount =
                (new TextRange(
                    RichTxtBxContent.Document.ContentStart,
                    RichTxtBxContent.Document.ContentEnd))
                .Text.Length;
            StatusTextBlock.Text = $"Document length: {charactersCount} characters.";
        }
    }
}
