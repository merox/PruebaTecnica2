namespace PruebaTecnica2.Services.Interfaces
{
    public interface ICrud<T, T2>
        where T : class
    {
        T2 Add(T ob);
        T2 Update(T ob);
        T2 Delete(object id);
        T2 GetById(object id);
        IEnumerable<T2> GetAll();
    }
}
