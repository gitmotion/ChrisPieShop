using ChrisPieShop.Models;
using Microsoft.AspNetCore.Components;

namespace ChrisPieShop.App.Pages
{
    public partial class PieCard
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }
}
