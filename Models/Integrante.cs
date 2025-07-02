class Integrante{
    public string Username{get;set;}
    public string Nombre{get;set;}
    public string Apellido{get;set;}
    public string Password{get;set;}
    public string Email{get;set;}
    public int Edad{get;set;}
    public string Escuela{get;set;}
    public Integrante(string Username, string Nombre, string Apellido, string Password, string Email, int Edad, string Escuela){
        this.Username = Username;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Password = Password;
        this.Email = Email;
        this.Edad = Edad;
        this.Escuela = Escuela;
    }
}