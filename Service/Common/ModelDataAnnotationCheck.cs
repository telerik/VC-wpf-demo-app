using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Common
{
    public class ModelDataAnnotationCheck : IModelDataAnnotationCheck
    {
        public void ValidateModelDataAnnotations<TDomainModel>(TDomainModel domainModel)
        {
            var validationResultList = new List<ValidationResult>();

            var validationContext = new ValidationContext(domainModel, null, null);

            var errorLog = new StringBuilder();

            if (!Validator.TryValidateObject(domainModel, validationContext, validationResultList, validateAllProperties: true))
            {
                foreach(ValidationResult validationResult in validationResultList)
                {
                    errorLog.Append(validationResult.ErrorMessage)
                                 .AppendLine();
                }
            }

            if (validationResultList.Count > 0)
            {
                throw new ArgumentException(errorLog.ToString());
            }
        }
    }
}
