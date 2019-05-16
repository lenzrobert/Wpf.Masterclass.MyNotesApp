using System.Windows;
using System.Windows.Controls;
using Wpf.Masterclass.MyNotesApp.Model;

namespace Wpf.Masterclass.MyNotesApp.View.UserControls
{
    /// <summary>
    /// Interaction logic for NotebookControl.xaml
    /// </summary>
    public partial class NotebookControl : UserControl
    {
        public Notebook DisplayNotebook
        {
            get
            {
                return (Notebook) GetValue(notebookProperty);
            }
            set
            {
                SetValue(notebookProperty, value);
            }
        }

        public static readonly DependencyProperty notebookProperty =
            DependencyProperty.Register(nameof(DisplayNotebook), typeof(Notebook), typeof(NotebookControl), new PropertyMetadata(null, SetValues));

        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           NotebookControl ntb = d as NotebookControl;

           if (notebookProperty != null)
           {
               ntb.TxtBlkNotebookName.Text = (e.NewValue as Notebook).Name;
           }

        }

        public NotebookControl()
        {
            InitializeComponent();
        }
    }
}
