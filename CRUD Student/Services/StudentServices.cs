using CRUD_Student.Models;

namespace CRUD_Student.Services;

public class StudentServices
{
    private List<Student> students;
    public StudentServices()
    {
        students = new List<Student>();
    }
    public void Add(Student added)
    {
        var id = Guid.NewGuid();
        added.Id = id;
        students.Add(added);
    }
    public bool Delete(Guid id)
    {
        var TF = false;
        foreach (var stdy in students)
        {
            if (stdy.Id == id)
            {
                TF = true;
                students.Remove(stdy);
                break;
            }
        }
        return TF;
    }
    public bool Update(Student obj)
    {
        var TF = false;
        for (var i = 0; i < students.Count; i++)
        {
            if (students[i].Id == obj.Id)
            {
                students[i] = obj;
                TF = true;
                break;
            }
        }
        return TF;
    }
    public Student GetById(Guid id)
    {
        foreach (Student stnd in students)
        {
            if (stnd.Id == id)
            {
                return stnd;
            }
        }
        return null;
    }
    public List<Student> GetAll()
    {
        return students;
    }
}
