namespace Service.Common
{
    public interface IModelDataAnnotationCheck
    {
        void ValidateModelDataAnnotations<TDomainModel>(TDomainModel domainModel);
    }
}
