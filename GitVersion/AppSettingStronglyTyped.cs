using Microsoft.Build.Framework;

namespace Dorssel.GitVersion;

/// <summary>
/// TODO
/// </summary>
public class AppSettingStronglyTyped
    : Microsoft.Build.Utilities.Task
{
    /// <summary>
    /// The name of the class which is going to be generated
    /// </summary>
    [Required]
    public string SettingClassName { get; set; } = null!;

    /// <summary>
    /// The name of the namespace where the class is going to be generated
    /// </summary>
    [Required]
    public string SettingNamespaceName { get; set; } = null!;

    /// <summary>
    /// List of files which we need to read with the defined format: 'propertyName:type:defaultValue' per line
    /// </summary>
    [Required]
#pragma warning disable CA1819 // Properties should not return arrays
    public ITaskItem[] SettingFiles { get; set; } = null!;
#pragma warning restore CA1819 // Properties should not return arrays

    /// <summary>
    /// The filename where the class was generated
    /// </summary>
    [Output]
    public string ClassNameFile { get; set; } = null!;

    /// <inheritdoc/>
    public override bool Execute()
    {
        //Read the input files and return a IDictionary<string, object> with the properties to be created. 
        //Any format error it will return false and log an error
        var (success, settings) = ReadProjectSettingFiles();
        if (!success)
        {
            return !Log.HasLoggedErrors;
        }
        //Create the class based on the Dictionary
        _ = CreateSettingClass(settings);

        return !Log.HasLoggedErrors;
    }

    bool CreateSettingClass(IDictionary<string, object>? settings)
    {
        throw new NotImplementedException();
    }

    (bool, IDictionary<string, object>?) ReadProjectSettingFiles()
    {
        var values = new Dictionary<string, object>();
        foreach (var item in SettingFiles)
        {
            var lineNumber = 0;

            var settingFile = item.GetMetadata("FullPath");
            foreach (var line in File.ReadLines(settingFile))
            {
                lineNumber++;

                var lineParse = line.Split(':');
                if (lineParse.Length != 3)
                {
                    Log.LogError(subcategory: null,
                                 errorCode: "APPS0001",
                                 helpKeyword: null,
                                 file: settingFile,
                                 lineNumber: lineNumber,
                                 columnNumber: 0,
                                 endLineNumber: 0,
                                 endColumnNumber: 0,
                                 message: "Incorrect line format. Valid format prop:type:defaultvalue");
                    return (false, null);
                }
                var value = GetValue(lineParse[1], lineParse[2]);
                if (!value.Item1)
                {
                    return (value.Item1, null);
                }

                values[lineParse[0]] = value.Item2;
            }
        }
        return (true, values);
    }

    Tuple<bool, string> GetValue(string v1, string v2)
    {
        throw new NotImplementedException();
    }
}
