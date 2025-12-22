using System;
using System.Reflection;
using System.Xml.Linq;
using AnimalLibrary;

namespace ClassDiagramGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //getting AnimalLibrary.dll
            Assembly assembly = typeof(Animal).Assembly;

            //creating XML
            XElement diagram = new XElement("ClassDiagram");

            diagram.Add(new XElement(
                "Assembly",
                new XAttribute("Name", assembly.GetName().Name),
                new XAttribute("Version", assembly.GetName().Version)
                ));

            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                if (type.Namespace == "AnimalLibrary")
                {
                    if (type.IsEnum)
                    {
                        AddEnumToXml(diagram, type);
                    }
                    else if (type.IsClass)
                    {
                        AddClassToXml(diagram, type);
                    }
                }
            }

            //save XML
            string fileName = "AnimalLibraryDiagram.xml";
            diagram.Save(fileName);
            Console.WriteLine($"XML диаграмма сохранена в файл: {fileName}");
            Console.WriteLine();

            Console.WriteLine(diagram.ToString());
        }

        static void AddEnumToXml(XElement XML, Type enumType)
        {
            XElement enumElement = new XElement(
                "Enum",
                new XAttribute("Name", enumType.Name),
                new XAttribute("FullName", enumType.FullName)
                );

            var commentAttr = enumType.GetCustomAttribute<CommentAttribute>();
            if (commentAttr != null)
            {
                enumElement.Add(new XAttribute("Comment", commentAttr.Comment));
            }

            XElement valuesElement = new XElement("Values");

            string[] enumNames = enumType.GetEnumNames();
            foreach (string valName in enumNames)
            {
                valuesElement.Add(new XElement("Value",
                    new XAttribute("Name", valName),
                    new XAttribute("Value", Convert.ToInt32(Enum.Parse(enumType, valName)))
                    ));
            }
            enumElement.Add(valuesElement);

            XML.Add(enumElement);
        }

        static void AddClassToXml(XElement XML, Type classType)
        {
            XElement classElement = new XElement(
                "Class",
                new XAttribute("Name", classType.Name),
                new XAttribute("FullName", classType.FullName),
                new XAttribute("IsAbstract", classType.IsAbstract));

            var commentAttr = classType.GetCustomAttribute<CommentAttribute>();
            if (commentAttr != null)
            {
                classElement.Add(new XAttribute("Comment", commentAttr.Comment));
            }

            if (classType.BaseType != null && classType.BaseType != typeof(object))
            {
                classElement.Add(new XElement(
                    "BaseClass",
                    new XAttribute("Name", classType.BaseType.Name)
                    ));
            }

            //Properties
            XElement propertiesElement = new XElement("Properties");
            PropertyInfo[] properties = classType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (PropertyInfo property in properties)
            {
                XElement propElement = new XElement(
                    "Property",
                    new XAttribute("Name", property.Name),
                    new XAttribute("Type", property.PropertyType.Name)
                    );

                var propComment = property.GetCustomAttribute<CommentAttribute>();
                if (propComment != null)
                {
                    propElement.Add(new XAttribute("Comment", propComment.Comment));
                }

                propertiesElement.Add(propElement);
            }
            classElement.Add(propertiesElement);

            //Methods
            XElement methodsElement = new XElement("Methods");
            MethodInfo[] methods = classType.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (MethodInfo method in methods)
            {
                if (method.IsSpecialName) continue;

                XElement methodElement = new XElement(
                    "Method",
                    new XAttribute("Name", method.Name),
                    new XAttribute("ReturnType", method.ReturnType.Name)
                    );

                var methodComment = method.GetCustomAttribute<CommentAttribute>();
                if (methodComment != null)
                {
                    methodElement.Add(new XAttribute("Comment", methodComment.Comment));
                }

                ParameterInfo[] parameters = method.GetParameters();
                if (parameters.Length > 0)
                {
                    XElement paramsElement = new XElement("Parameters");
                    foreach (ParameterInfo param in parameters)
                    {
                        paramsElement.Add(new XElement(
                            "Parameter",
                            new XAttribute("Name", param.Name),
                            new XAttribute("Type", param.ParameterType.Name)
                            ));
                    }
                    methodElement.Add(paramsElement);
                }

                methodsElement.Add(methodElement);
            }
            classElement.Add(methodsElement);

            //Constructors
            XElement constructorsElement = new XElement("Constructors");
            ConstructorInfo[] constructors = classType.GetConstructors(
                BindingFlags.Public | BindingFlags.Instance);

            foreach (ConstructorInfo constructor in constructors)
            {
                XElement constructorElement = new XElement("Constructor");

                var constructorComment = constructor.GetCustomAttribute<CommentAttribute>();
                if (constructorComment != null)
                {
                    constructorElement.Add(new XAttribute("Comment", constructorComment.Comment));
                }

                ParameterInfo[] parameters = constructor.GetParameters();
                if (parameters.Length > 0)
                {
                    XElement paramsElement = new XElement("Parameters");
                    foreach (ParameterInfo param in parameters)
                    {
                        paramsElement.Add(new XElement("Parameter",
                            new XAttribute("Name", param.Name),
                            new XAttribute("Type", param.ParameterType.Name)));
                    }
                    constructorElement.Add(paramsElement);
                }

                constructorsElement.Add(constructorElement);
            }
            classElement.Add(constructorsElement);

            XML.Add(classElement);
        }
    }
}

