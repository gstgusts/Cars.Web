using Cars.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public CarsByYearModel CarsByYear()
        {
            return new CarsByYearModel
            {
                Cols = new ColModel[] {
                    new ColModel {
                        Id = "",
                        Label = "Topping",
                        Pattern = "",
                        Type = "string"
                    },
                    new ColModel {
                        Id = "",
                        Label = "Slices",
                        Pattern = "",
                        Type = "number"
                    }
                },
                Rows = new RowModel[] {
                    new RowModel
                    {
                        ColData = new RowDataItem[]
                        {
                            new RowDataItem {
                                Value = "Mushrooms",
                                Format = ""
                            },
                            new RowDataItem {
                                Value = 3,
                                Format = ""
                            }
                        }
                    },
                     new RowModel
                    {
                        ColData = new RowDataItem[]
                        {
                            new RowDataItem {
                                Value = "Onions",
                                Format = ""
                            },
                            new RowDataItem {
                                Value = 1,
                                Format = ""
                            }
                        }
                    }
                }
            };
        }
    }
}
