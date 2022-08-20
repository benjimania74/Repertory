namespace Main;

using FormContent;

public class MainForm : Form {
    private bool IsCharged = false;
    public static MainForm Instance;
    private List<string> EntryList;
    private PanelCreator PanelObj;
    public TextBox Bar;
    private ListCreator ListControl;
    private ButtonCreator CreateButton;
    private string path = @".\repertory.ppr";

    public MainForm(){
        if(!File.Exists(path)){CreateFile();}

        Instance = this;
        EntryList = new List<string>();

        SuspendLayout();
        Initializer();

        PanelObj = MainObject.Panel.PanelObject;
        Bar = MainObject.Bar.TextBox;
        ListControl = MainObject.MainList.List;
        CreateButton = MainObject.CreateButton.Button;

        SeeFromString();

        PanelObj.Controls.Add(Bar);
        PanelObj.Controls.Add(ListControl);
        PanelObj.Controls.Add(CreateButton);

        Controls.Add(PanelObj);

        ResumeLayout(false);
        PerformLayout();
        IsCharged = true;
    }

    private void Initializer(){
        Text = "PayPalRepertory";
        Size = MinimumSize = MaximumSize = new Size(200, 400);
        Icon = new Icon(@"./icon.ico");
        StartPosition = FormStartPosition.CenterScreen;

        EntryList = new List<string>();
        new MainObject.Panel();
        new MainObject.CreateButton();
        new MainObject.MainList();
        new MainObject.Bar();
        LoadList();
    }

    public void LoadList(){
        EntryList = new List<string>();
        using (StreamReader sr = File.OpenText(path)){
            string? s = "";
            while ((s = sr.ReadLine()) != null){
                if(s.Contains(":")){
                    EntryList.Add(s);
                }
            }
            sr.Close();
        }
        if(IsCharged){
            SeeFromString();
        }
    }

    public void SeeFromString(string ToSee = ""){
        ListControl.Items.Clear();
        EntryList.ForEach((Entry) => {
            if(Entry.Contains(ToSee)){
                ListControl.Items.Add(Entry.Split(":")[0].Replace("|.|", ":"));
            }
        });
    }

    public void AddInList(string Entry){
        EntryList.Add(Entry);
        Save();
    }

    public void RemoveFromList(string Entry){
        EntryList.Remove(Entry);
        Save();
    }

    public void ChangeValue(string Ancient, string New){
        EntryList.Remove(Ancient);
        EntryList.Add(New);
        Save();
    }

    public void Save(){
        CreateFile();
        try{
            using StreamWriter file = new(path, append: true);
            EntryList.ForEach((e) => {
                file.WriteLineAsync(e);
            });
        }
        catch (Exception){Close();}
        LoadList();
    }

    public string GetValue(string Key){
        string Returned = "";
        EntryList.ForEach((Entry) => {
            if(Entry.Split(":")[0].Equals(Key)){
                Returned = Entry.Split(":")[1];
            }
        });
        return Returned;
    }

    private void CreateFile(){
        try{
            using (FileStream fs = File.Create(path)){
                byte[] info = System.Text.Encoding.ASCII.GetBytes("");
                fs.Write(info, 0, info.Length);
                fs.Close();
            }
        }
        catch (Exception){Close();}
    }
}