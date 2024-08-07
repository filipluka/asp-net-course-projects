using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewModels;

public class CourseIndexViewModel : Controller
{
    public IEnumerable<CourseViewModel> Courses { get; set; } = [];
}
