﻿// This code is part of the JM Tools Build System library maintained by Joshua McLean (http://mrjoshuamclean.com)
// It is released for free under the MIT open source license (LICENSE.txt)

namespace JoshuaMcLean.BuildSystem
{
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.IO;
    using UnityEngine;

    static public class Extensions
    {
        public static string ToLiteral( this string input ) {
            using ( var writer = new StringWriter() ) {
                using ( var provider = CodeDomProvider.CreateProvider( "CSharp" ) ) {
                    provider.GenerateCodeFromExpression( new CodePrimitiveExpression( input ), writer, new CodeGeneratorOptions { IndentString = "\t" } );
                    var literal = writer.ToString();
                    literal = literal.Replace( string.Format( "\" +{0}\t\"", System.Environment.NewLine ), "" );
                    return literal;
                }
            }
        }

        static public void SetAllColors( this GUIStyle a_style, Color a_color ) {
            a_style.normal.textColor = a_color;
            a_style.active.textColor = a_color;
            a_style.focused.textColor = a_color;
            a_style.hover.textColor = a_color;
            a_style.onActive.textColor = a_color;
            a_style.onFocused.textColor = a_color;
            a_style.onHover.textColor = a_color;
            a_style.onNormal.textColor = a_color;
        }
    }
}