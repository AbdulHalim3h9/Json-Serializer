using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace assignment_1
{
    public class JsonFormatter
    {
        public static string Convert(object input)
        {
            int iindex = 1;
            StringBuilder JsonTextSB = new StringBuilder();
            
            static string ConvertToJson(object inputText, StringBuilder SB, int index)
            {
                Type t = inputText.GetType();
                PropertyInfo[] properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

                //To add comma after '}'
                for (int i = SB.Length - 1; i >= 0; i--)
                {
                    if (SB[i].ToString().Equals("]"))
                    {
                        SB[i + 1] = ',';
                        break;
                    }
                    if (SB[i].ToString().Equals("}"))
                    {
                        SB[i + 1] = ',';
                        break;
                    }
                }

                SB.AppendLine("{");
                foreach (var item in properties)
                {
                    for (int i = 0; i < index; ++i)
                    {
                        //adding some space to indent the document
                        SB.Append("   ");
                    }
                    SB.Append($"\"{item.Name}\":");
                    if (item.GetValue(inputText).ToString().StartsWith($"{t.Namespace}"))
                    {

                        ConvertToJson(item.GetValue(inputText), SB, ++index);
                        --index;
                    }
                    else if (item.GetValue(inputText).ToString().Contains("System.Collections") && item.GetValue(inputText).ToString().Contains($"{t.Namespace}"))
                    {
                        // To Add a comma
                        for (int i = SB.Length - 1; i >= 0; i--)
                        {
                            if (SB[i].ToString().Equals("}"))
                            {
                                break;
                            }
                            if (SB[i].ToString().Equals("]"))
                            {
                                SB[i + 1] = ',';
                                break;
                            }
                        }
                        SB.AppendLine("[");
                        var lst = item.GetValue(inputText);
                        foreach (var lt in (dynamic)lst)
                        {
                            for (int i = 0; i < index; ++i)
                            {
                                //indenting
                                SB.Append("   ");
                            }
                            ConvertToJson(lt, SB, ++index);
                            --index;
                        }
                        for (int i = 0; i < index; ++i)
                        {
                            //Indenting
                            SB.Append("   ");
                        }
                        SB.AppendLine("]");
                    }
                    else
                    {
                        SB.Append($"\"{item.GetValue(inputText)}\",\n");
                    }

                    if (item == properties.Last())
                    {
                        // Removing The Comma for the last pair
                        SB.Remove(SB.Length - 2, 2);
                        SB.Append("\n");
                    }
                }
                for (int i = 1; i < index; i++)
                {
                    //indenting
                    SB.Append("   ");
                }
                SB.AppendLine("}");
                string Jsontext = SB.ToString();
                return Jsontext;
            }
            return ConvertToJson(input, JsonTextSB, iindex);
        }
    }

}
