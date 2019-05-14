using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;

namespace Wpf.Masterclass.MyNotesApp.View
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        private SpeechRecognitionEngine _speechRecognizer;
       
        
        public NotesWindow()
        {
            InitializeComponent();
            InitializeSpeechEngine();
            InitializeFontFamilies();
            InitializeFontSizes();

        }

        private void InitializeFontSizes()
        {
            CboxFontSize.ItemsSource = new List<double>()
            {
                8,
                9,
                10,
                12,
                14,
                16,
                20,
                24,
                28,
                72
            };
            
        }

        private void InitializeFontFamilies()
        {
            CboxFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
        }

        private void InitializeSpeechEngine()
        {
            RecognizerInfo currentCluture = SpeechRecognitionEngine.InstalledRecognizers()
                .FirstOrDefault(r => r.Culture.Equals(Thread.CurrentThread.CurrentCulture));
            if (currentCluture != null)
            {
                _speechRecognizer = new SpeechRecognitionEngine(currentCluture);
                GrammarBuilder grammarBuilder = new GrammarBuilder();
                grammarBuilder.AppendDictation();
                Grammar grammar = new Grammar(grammarBuilder);
                
                _speechRecognizer.LoadGrammar(grammar);
                _speechRecognizer.SetInputToDefaultAudioDevice();
                _speechRecognizer.SpeechRecognized += Recognizer_SpeechRecognized;
            }
        }

        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string recongnizedText = e.Result.Text;
            RichTxtBxContent.Document.Blocks.Add(new Paragraph(new Run(recongnizedText)));
        }

        private void BtnSpeech_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonEnabled = ((ToggleButton) sender).IsChecked ?? false;
            if (isButtonEnabled)
            {
                _speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            else
            {
                _speechRecognizer.RecognizeAsyncStop();
            }
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

        private void RichTextBxContent_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedWeight = RichTxtBxContent.Selection.GetPropertyValue(Inline.FontWeightProperty);
            BtnBold.IsChecked = (selectedWeight != DependencyProperty.UnsetValue) &&
                                (selectedWeight.Equals(FontWeights.Bold));

            var selectedStyle = RichTxtBxContent.Selection.GetPropertyValue(Inline.FontStyleProperty);
            BtnItalic.IsChecked = (selectedStyle != DependencyProperty.UnsetValue) &&
                                  (selectedWeight.Equals(FontStyles.Italic));

            var selectedDecoration = RichTxtBxContent.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            BtnUnderline.IsChecked = (selectedDecoration != DependencyProperty.UnsetValue) &&
                                     (selectedDecoration.Equals(TextDecorations.Underline));

            CboxFontFamily.SelectedItem = RichTxtBxContent.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            CboxFontSize.Text = (RichTxtBxContent.Selection.GetPropertyValue(Inline.FontSizeProperty)).ToString();

        }
        
        private void BtnBold_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonEnabled = ((ToggleButton) sender).IsChecked ?? false;
            if (isButtonEnabled)
            {
                RichTxtBxContent.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
            else
            {
                RichTxtBxContent.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
            }
         
        }

        private void BtnItalic_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonEnabled = ((ToggleButton) sender).IsChecked ?? false;
            if (isButtonEnabled)
            {
                RichTxtBxContent.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
            }
            else
            {
                RichTxtBxContent.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Normal);
            }
        }

        private void BtnUnderline_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonEnabled = ((ToggleButton) sender).IsChecked ?? false;
            if (isButtonEnabled)
            {
                RichTxtBxContent.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
            {
                ((TextDecorationCollection) RichTxtBxContent.Selection.GetPropertyValue(Inline.TextDecorationsProperty)).TryRemove(TextDecorations.Underline, out TextDecorationCollection textDecorations);
                RichTxtBxContent.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, textDecorations);
            }
        }


        private void CboxFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CboxFontFamily.SelectedItem != null)
            {
                RichTxtBxContent.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, CboxFontFamily.SelectedItem);
            }
        }

        private void CboxFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(CboxFontSize.Text, out double selectedValue))
            {
                RichTxtBxContent.Selection.ApplyPropertyValue(Inline.FontSizeProperty, selectedValue);
            }
        }
    }
}
