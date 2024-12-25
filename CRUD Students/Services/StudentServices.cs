using CRUD_Students.Models;

namespace CRUD_Students.Services;

public class StudentServices
{
    private List<Student> students;
    public StudentServices()
    {
        students = new List<Student>();
    }
    public Student AddStudent(Student added)
    {
        added.Id = Guid.NewGuid();
        students.Add(added);
        return added;
    }
    public Student GetById(Guid id)
    {
        foreach (var student in students)
        {
            if (student.Id == id)
            {
                return student;
            }
        }
        return null;
    }
    public bool Delete(Guid id)
    {
        var stnd = GetById(id);
        if (stnd is null)
        {
            return false;
        }
        students.Remove(stnd);
        return true;
    }

    public bool Update(Student obj)
    {
        var id = GetById(obj.Id);
        if (id is null)
        {
            return false;
        }
        students[students.IndexOf(id)] = obj;
        return true;
    }
    public List<Student> GetAll()
    {
        return students;
    }
}
