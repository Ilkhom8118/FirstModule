namespace CrudOop.Student;

public class StudentService
{
    private List<Student> ListedStudent;

    public StudentService()
    {
        ListedStudent = new List<Student>();
    }
    public Student AddStudent(Student student)
    {
        student.Id = Guid.NewGuid();
        ListedStudent.Add(student);
        return student;
    }
    public bool DeleteStudent(Guid studentId)
    {
        var exists = false;
        foreach (var student in ListedStudent)
        {
            if (student.Id == studentId)
            {
                ListedStudent.Remove(student);
                exists = true;
                break;
            }
        }
        return exists;
    }
    public bool UpdateStudent(Student updateStudent)
    {
        var exists = false;
        for (var i = 0; i < ListedStudent.Count; i++)
        {
            if (ListedStudent[i].Id == updateStudent.Id)
            {
                ListedStudent[i] = updateStudent;
                exists = true;
            }
        }
        return exists;
    }
    public Student GetById(Guid studentId)
    {
        foreach (var student in ListedStudent)
        {
            if (student.Id == studentId)
            {
                return student;
            }
        }
        return null;
    }
    public List<Student> GetAllStudent()
    {
        return ListedStudent;
    }
}
