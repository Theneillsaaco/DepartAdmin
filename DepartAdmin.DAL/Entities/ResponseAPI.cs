namespace DepartAdmin.DAL.Entities;
public class ResponseAPI<T>
{
    public bool response { get; set; }
    public T? Valor { get; set; }
    public string? Mensaje { get; set; }
}
