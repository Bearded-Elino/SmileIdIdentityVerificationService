using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace IdentityVerificationService.Localization
{
    public static class IdentityVerificationServiceLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(IdentityVerificationServiceConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(IdentityVerificationServiceLocalizationConfigurer).GetAssembly(),
                        "IdentityVerificationService.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
