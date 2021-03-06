﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIF.Visualization.Excel.Networking
{
    class SchemaStrings
    {
        public static string getReportXSD()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<xs:schema version=""1.0"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">

  <xs:element name=""test"" type=""inspectionRequest""/>

  <xs:complexType name=""inspectionRequest"">
    <xs:sequence>
      <xs:element name=""cells"" type=""cells"" minOccurs=""0""/>
      <xs:element name=""findings"" type=""findings"" minOccurs=""0""/>
    </xs:sequence>
    <xs:attribute name=""title"" type=""xs:string""/>
    <xs:attribute name=""file"" type=""xs:string""/>
  </xs:complexType>

  <xs:complexType name=""cells"">
    <xs:sequence>
      <xs:element name=""input"" minOccurs=""0"">
        <xs:complexType>
          <xs:sequence>
            <xs:element name=""cell"" type=""cell"" minOccurs=""0"" maxOccurs=""unbounded""/>
          </xs:sequence>
        </xs:complexType>
      </xs:element>
      <xs:element name=""intermediate"" minOccurs=""0"">
        <xs:complexType>
          <xs:sequence>
            <xs:element name=""cell"" type=""cell"" minOccurs=""0"" maxOccurs=""unbounded""/>
          </xs:sequence>
        </xs:complexType>
      </xs:element>
      <xs:element name=""output"" minOccurs=""0"">
        <xs:complexType>
          <xs:sequence>
            <xs:element name=""cell"" type=""cell"" minOccurs=""0"" maxOccurs=""unbounded""/>
          </xs:sequence>
        </xs:complexType>
      </xs:element>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name=""cell"">
    <xs:complexContent>
      <xs:extension base=""basicAbstractElement"">
        <xs:sequence/>
        <xs:attribute name=""location"" type=""xs:string""/>
        <xs:attribute name=""content"" type=""xs:string""/>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""basicAbstractElement"" abstract=""true"">
    <xs:complexContent>
      <xs:extension base=""abstractElement"">
        <xs:sequence/>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""abstractElement"" abstract=""true"">
    <xs:sequence/>
  </xs:complexType>

  <xs:complexType name=""findings"">
    <xs:sequence>
      <xs:element name=""testedRule"" type=""testedRule"" minOccurs=""0"" maxOccurs=""unbounded""/>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name=""testedRule"">
    <xs:sequence>
      <xs:element name=""violations"" type=""abstractViolation"" minOccurs=""0"" maxOccurs=""unbounded""/>
      <xs:element name=""testedPolicy"" type=""abstractPolicyRule"" minOccurs=""0""/>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name=""abstractViolation"" abstract=""true"">
    <xs:sequence/>
    <xs:attribute name=""causingelement"" type=""xs:string""/>
    <xs:attribute name=""location"" type=""xs:string""/>
    <xs:attribute name=""description"" type=""xs:string""/>
    <xs:attribute name=""severity"" type=""xs:double""/>
  </xs:complexType>

  <xs:complexType name=""singleviolation"">
    <xs:complexContent>
      <xs:extension base=""abstractViolation"">
        <xs:sequence/>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""violationgroup"">
    <xs:complexContent>
      <xs:extension base=""abstractViolation"">
        <xs:sequence>
          <xs:element name=""singleviolation"" type=""singleviolation"" minOccurs=""0"" maxOccurs=""unbounded""/>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""abstractPolicyRule"" abstract=""true"">
    <xs:sequence/>
    <xs:attribute name=""severityWeight"" type=""xs:double""/>
    <xs:attribute name=""type"" type=""policyRuleType""/>
    <xs:attribute name=""possibleSolution"" type=""xs:string""/>
    <xs:attribute name=""author"" type=""xs:string""/>
    <xs:attribute name=""background"" type=""xs:string""/>
    <xs:attribute name=""description"" type=""xs:string""/>
    <xs:attribute name=""name"" type=""xs:string""/>
  </xs:complexType>

  <xs:complexType name=""formulaComplexityPolicyRule"">
    <xs:complexContent>
      <xs:extension base=""monolithicPolicyRule"">
        <xs:sequence>
          <xs:element name=""formulaComplexityMaxNesting"" type=""xs:int"" minOccurs=""0""/>
          <xs:element name=""formulaComplexityMaxOperations"" type=""xs:int"" minOccurs=""0""/>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""monolithicPolicyRule"" abstract=""true"">
    <xs:complexContent>
      <xs:extension base=""abstractPolicyRule"">
        <xs:sequence/>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""noConstantsPolicyRule"">
    <xs:complexContent>
      <xs:extension base=""monolithicPolicyRule"">
        <xs:sequence>
          <xs:element name=""ignoredConstants"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""ignoredConstant"" type=""xs:anyType"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""ignoredFunctions"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""functionName"" type=""xs:string"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""ignoredCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""location"" type=""xs:string"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""sanityRules"">
    <xs:complexContent>
      <xs:extension base=""monolithicPolicyRule"">
        <xs:sequence>
          <xs:element name=""sanityCheckingCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""location"" type=""xs:string"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""sanityValueCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""location"" type=""xs:string"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""sanityConstraintCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""location"" type=""xs:string"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""sanityExplanationCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""location"" type=""xs:string"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""sanityWarnings"" type=""xs:boolean"" minOccurs=""0""/>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""readingDirectionPolicyRule"">
    <xs:complexContent>
      <xs:extension base=""monolithicPolicyRule"">
        <xs:sequence>
          <xs:element name=""leftToRight"" type=""xs:boolean"" minOccurs=""0""/>
          <xs:element name=""topToBottom"" type=""xs:boolean"" minOccurs=""0""/>
          <xs:element name=""ignoredCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""location"" type=""xs:string"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""rule"">
    <xs:complexContent>
      <xs:extension base=""monolithicPolicyRule"">
        <xs:sequence>
          <xs:element name=""invariants"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:choice minOccurs=""0"" maxOccurs=""unbounded"">
                  <xs:element name=""compare"" type=""binaryCondition""/>
                  <xs:element name=""interval"" type=""ternaryCondition""/>
                  <xs:element name=""count"" type=""elementCountCondition""/>
                </xs:choice>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""testInputs"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""testInput"" type=""testInput"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""postconditions"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:choice minOccurs=""0"" maxOccurs=""unbounded"">
                  <xs:element name=""compare"" type=""binaryCondition""/>
                  <xs:element name=""interval"" type=""ternaryCondition""/>
                  <xs:element name=""count"" type=""elementCountCondition""/>
                </xs:choice>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""binaryCondition"">
    <xs:complexContent>
      <xs:extension base=""abstractCondition"">
        <xs:sequence>
          <xs:element name=""relation"" type=""xs:string"" minOccurs=""0""/>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""abstractCondition"" abstract=""true"">
    <xs:sequence>
      <xs:element name=""elementType"" type=""xs:string"" minOccurs=""0""/>
      <xs:element name=""property"" type=""xs:string"" minOccurs=""0""/>
      <xs:element name=""target"" type=""xs:string"" minOccurs=""0""/>
      <xs:element name=""value"" type=""xs:string"" minOccurs=""0""/>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name=""ternaryCondition"">
    <xs:complexContent>
      <xs:extension base=""abstractCondition"">
        <xs:sequence>
          <xs:element name=""relation"" type=""xs:string"" minOccurs=""0""/>
          <xs:element name=""value2"" type=""xs:double"" minOccurs=""0""/>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""elementCountCondition"">
    <xs:complexContent>
      <xs:extension base=""abstractCondition"">
        <xs:sequence/>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""testInput"">
    <xs:sequence>
      <xs:element name=""target"" type=""xs:string"" minOccurs=""0""/>
      <xs:element name=""type"" type=""cellContentType"" minOccurs=""0""/>
      <xs:element name=""value"" type=""xs:string"" minOccurs=""0""/>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name=""dynamicPolicy"">
    <xs:complexContent>
      <xs:extension base=""policy"">
        <xs:sequence>
          <xs:element name=""spreadsheetFilePath"" type=""xs:string"" minOccurs=""0""/>
          <xs:element name=""inputCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""inputCell"" type=""ioCellInfo"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""outputCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""outputCell"" type=""ioCellInfo"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""policy"">
    <xs:sequence>
      <xs:element name=""rules"" type=""dynamicPolicyRuleListWrapper"" minOccurs=""0""/>
    </xs:sequence>
    <xs:attribute name=""author"" type=""xs:string""/>
    <xs:attribute name=""description"" type=""xs:string""/>
    <xs:attribute name=""name"" type=""xs:string""/>
  </xs:complexType>

  <xs:complexType name=""ioCellInfo"">
    <xs:sequence>
      <xs:element name=""a1Address"" type=""xs:string"" minOccurs=""0""/>
      <xs:element name=""name"" type=""xs:string"" minOccurs=""0""/>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name=""dynamicPolicyRuleListWrapper"">
    <xs:sequence>
      <xs:element name=""rule"" type=""rule"" minOccurs=""0"" maxOccurs=""unbounded""/>
    </xs:sequence>
  </xs:complexType>

  <xs:simpleType name=""policyRuleType"">
    <xs:restriction base=""xs:string"">
      <xs:enumeration value=""STATIC""/>
      <xs:enumeration value=""DYNAMIC""/>
      <xs:enumeration value=""SANITY""/>
      <xs:enumeration value=""COMPOSITE""/>
    </xs:restriction>
  </xs:simpleType>

  <xs:simpleType name=""cellContentType"">
    <xs:restriction base=""xs:string"">
      <xs:enumeration value=""BLANK""/>
      <xs:enumeration value=""BOOLEAN""/>
      <xs:enumeration value=""TEXT""/>
      <xs:enumeration value=""NUMERIC""/>
      <xs:enumeration value=""ERROR""/>
    </xs:restriction>
  </xs:simpleType>
</xs:schema>";
        }
        public static string getRequestXSD()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<xs:schema version=""1.0"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">

  <xs:element name=""policyList"" type=""policyList""/>

  <xs:complexType name=""policyList"">
    <xs:sequence>
      <xs:element name=""dynamicPolicy"" type=""dynamicPolicy"" minOccurs=""0""/>
      <xs:element name=""sanityRules"" type=""sanityRules"" minOccurs=""0""/>
      <xs:element name=""readingDirectionPolicyRule"" type=""readingDirectionPolicyRule"" minOccurs=""0""/>
      <xs:element name=""noConstantsPolicyRule"" type=""noConstantsPolicyRule"" minOccurs=""0""/>
      <xs:element name=""formulaComplexityPolicyRule"" type=""formulaComplexityPolicyRule"" minOccurs=""0""/>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name=""dynamicPolicy"">
    <xs:complexContent>
      <xs:extension base=""policy"">
        <xs:sequence>
          <xs:element name=""spreadsheetFilePath"" type=""xs:string"" minOccurs=""0""/>
          <xs:element name=""inputCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""inputCell"" type=""ioCellInfo"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""outputCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""outputCell"" type=""ioCellInfo"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""policy"">
    <xs:sequence>
      <xs:element name=""rules"" type=""dynamicPolicyRuleListWrapper"" minOccurs=""0""/>
    </xs:sequence>
    <xs:attribute name=""author"" type=""xs:string""/>
    <xs:attribute name=""description"" type=""xs:string""/>
    <xs:attribute name=""name"" type=""xs:string""/>
  </xs:complexType>

  <xs:complexType name=""ioCellInfo"">
    <xs:sequence>
      <xs:element name=""a1Address"" type=""xs:string"" minOccurs=""0""/>
      <xs:element name=""name"" type=""xs:string"" minOccurs=""0""/>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name=""dynamicPolicyRuleListWrapper"">
    <xs:sequence>
      <xs:element name=""rule"" type=""rule"" minOccurs=""0"" maxOccurs=""unbounded""/>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name=""rule"">
    <xs:complexContent>
      <xs:extension base=""monolithicPolicyRule"">
        <xs:sequence>
          <xs:element name=""invariants"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:choice minOccurs=""0"" maxOccurs=""unbounded"">
                  <xs:element name=""compare"" type=""binaryCondition""/>
                  <xs:element name=""interval"" type=""ternaryCondition""/>
                  <xs:element name=""count"" type=""elementCountCondition""/>
                </xs:choice>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""testInputs"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""testInput"" type=""testInput"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""postconditions"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:choice minOccurs=""0"" maxOccurs=""unbounded"">
                  <xs:element name=""compare"" type=""binaryCondition""/>
                  <xs:element name=""interval"" type=""ternaryCondition""/>
                  <xs:element name=""count"" type=""elementCountCondition""/>
                </xs:choice>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""monolithicPolicyRule"" abstract=""true"">
    <xs:complexContent>
      <xs:extension base=""abstractPolicyRule"">
        <xs:sequence/>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""abstractPolicyRule"" abstract=""true"">
    <xs:sequence/>
    <xs:attribute name=""severityWeight"" type=""xs:double""/>
    <xs:attribute name=""type"" type=""policyRuleType""/>
    <xs:attribute name=""possibleSolution"" type=""xs:string""/>
    <xs:attribute name=""author"" type=""xs:string""/>
    <xs:attribute name=""background"" type=""xs:string""/>
    <xs:attribute name=""description"" type=""xs:string""/>
    <xs:attribute name=""name"" type=""xs:string""/>
  </xs:complexType>

  <xs:complexType name=""binaryCondition"">
    <xs:complexContent>
      <xs:extension base=""abstractCondition"">
        <xs:sequence>
          <xs:element name=""relation"" type=""xs:string"" minOccurs=""0""/>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""abstractCondition"" abstract=""true"">
    <xs:sequence>
      <xs:element name=""elementType"" type=""xs:string"" minOccurs=""0""/>
      <xs:element name=""property"" type=""xs:string"" minOccurs=""0""/>
      <xs:element name=""target"" type=""xs:string"" minOccurs=""0""/>
      <xs:element name=""value"" type=""xs:string"" minOccurs=""0""/>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name=""ternaryCondition"">
    <xs:complexContent>
      <xs:extension base=""abstractCondition"">
        <xs:sequence>
          <xs:element name=""relation"" type=""xs:string"" minOccurs=""0""/>
          <xs:element name=""value2"" type=""xs:double"" minOccurs=""0""/>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""elementCountCondition"">
    <xs:complexContent>
      <xs:extension base=""abstractCondition"">
        <xs:sequence/>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""testInput"">
    <xs:sequence>
      <xs:element name=""target"" type=""xs:string"" minOccurs=""0""/>
      <xs:element name=""type"" type=""cellContentType"" minOccurs=""0""/>
      <xs:element name=""value"" type=""xs:string"" minOccurs=""0""/>
    </xs:sequence>
  </xs:complexType>

  <xs:complexType name=""formulaComplexityPolicyRule"">
    <xs:complexContent>
      <xs:extension base=""monolithicPolicyRule"">
        <xs:sequence>
          <xs:element name=""formulaComplexityMaxNesting"" type=""xs:int"" minOccurs=""0""/>
          <xs:element name=""formulaComplexityMaxOperations"" type=""xs:int"" minOccurs=""0""/>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""noConstantsPolicyRule"">
    <xs:complexContent>
      <xs:extension base=""monolithicPolicyRule"">
        <xs:sequence>
          <xs:element name=""ignoredConstants"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""ignoredConstant"" type=""xs:anyType"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""ignoredFunctions"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""functionName"" type=""xs:string"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""ignoredCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""location"" type=""xs:string"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""sanityRules"">
    <xs:complexContent>
      <xs:extension base=""monolithicPolicyRule"">
        <xs:sequence>
          <xs:element name=""sanityCheckingCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""location"" type=""xs:string"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""sanityValueCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""location"" type=""xs:string"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""sanityConstraintCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""location"" type=""xs:string"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""sanityExplanationCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""location"" type=""xs:string"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
          <xs:element name=""sanityWarnings"" type=""xs:boolean"" minOccurs=""0""/>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:complexType name=""readingDirectionPolicyRule"">
    <xs:complexContent>
      <xs:extension base=""monolithicPolicyRule"">
        <xs:sequence>
          <xs:element name=""leftToRight"" type=""xs:boolean"" minOccurs=""0""/>
          <xs:element name=""topToBottom"" type=""xs:boolean"" minOccurs=""0""/>
          <xs:element name=""ignoredCells"" minOccurs=""0"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""location"" type=""xs:string"" minOccurs=""0"" maxOccurs=""unbounded""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>
  </xs:complexType>

  <xs:simpleType name=""cellContentType"">
    <xs:restriction base=""xs:string"">
      <xs:enumeration value=""BLANK""/>
      <xs:enumeration value=""BOOLEAN""/>
      <xs:enumeration value=""TEXT""/>
      <xs:enumeration value=""NUMERIC""/>
      <xs:enumeration value=""ERROR""/>
    </xs:restriction>
  </xs:simpleType>

  <xs:simpleType name=""policyRuleType"">
    <xs:restriction base=""xs:string"">
      <xs:enumeration value=""STATIC""/>
      <xs:enumeration value=""DYNAMIC""/>
      <xs:enumeration value=""SANITY""/>
      <xs:enumeration value=""COMPOSITE""/>
    </xs:restriction>
  </xs:simpleType>
</xs:schema>";
        }
    }
}
