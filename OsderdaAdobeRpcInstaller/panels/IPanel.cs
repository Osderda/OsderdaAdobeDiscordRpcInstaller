using System.Windows.Forms;
using static OsderdaAdobeRpcInstaller.main;

namespace OsderdaAdobeRpcInstaller.Panels {
    public interface IPanel {
        void OnShow();
        void SetWindow(main window);
        string Title { get; }   
        UserControl Control { get; }
        PanelTypes PreviousPanel { get; }
        PanelTypes NextPanel { get; }

    }
}
