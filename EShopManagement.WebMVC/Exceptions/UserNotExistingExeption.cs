using EShopManagement.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagement.WebMVC.Exceptions
{

    public class ImageNotUploadedException : EShopManagementException
    {

    
        public ImageNotUploadedException( )
            : base($"The uploaded file is not an image.")
        {
 
        }
    }
}
