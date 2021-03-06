﻿using SIF.Visualization.Excel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SIF.Visualization.Excel.ScenarioCore;

namespace SIF.Visualization.Excel.ScenarioCore.Visitor
{
    class ScenarioToXMLVisitor : IVisitor
    {
        public object Visit(Core.WorkbookModel n)
        {
            var root = new XElement("SIF.Scenario");
            root.Add(new XAttribute("Title", NullCheck(n.Title)));
            root.Add(new XAttribute("Spreadsheet", NullCheck(n.Spreadsheet)));
            root.Add(new XAttribute("PolicyPath", NullCheck(n.PolicyPath)));

            //save scenarios
            foreach (var scen in n.Scenarios)
            {
                if (scen != null) root.Add(scen.Accept(this) as XElement);
            }

            return root;
        }

        public object Visit(Scenario n)
        {
            var root = new XElement("Scenario");
            root.Add(new XAttribute("Title", NullCheck(n.Title)));
            root.Add(new XAttribute("Description", NullCheck(n.Description)));
            root.Add(new XAttribute("Author", NullCheck(n.Author)));
            root.Add(new XAttribute("CreationDate", n.CrationDate));
            root.Add(new XAttribute("Rating", n.Rating));

            var inputElements = this.SaveInputs(n);
            if (inputElements != null) root.Add(inputElements);

            var intermediateElements = this.SaveIntermediates(n);
            if (intermediateElements != null) root.Add(intermediateElements);

            var resultElements = this.SaveResults(n);
            if (resultElements != null) root.Add(resultElements);


            return root;
        }

        public object Visit(InputCellData n)
        {
            var root = new XElement("InputCellData");
            if (n.Location != null) root.Add(new XElement("Location", n.Location));
            if (n.Content != null) root.Add(new XElement("Content", n.Content));
            root.Add(new XElement("CellType", n.CellType));

            return root;
        }

        public object Visit(SanityConstraintCellData n)
        {
            var root = new XElement("SanityConstraintCellData");
            if (n.Location != null) root.Add(new XElement("Location", n.Location));
            if (n.Content != null) root.Add(new XElement("Content", n.Content));
            root.Add(new XElement("CellType", n.CellType));

            return root;
        }

        public object Visit(SanityExplanationCellData n)
        {
            var root = new XElement("SanityExplanationCellData");
            if (n.Location != null) root.Add(new XElement("Location", n.Location));
            if (n.Content != null) root.Add(new XElement("Content", n.Content));
            root.Add(new XElement("CellType", n.CellType));

            return root;
        }
        public object Visit(SanityValueCellData n)
        {
            var root = new XElement("SanityValueCellData");
            if (n.Location != null) root.Add(new XElement("Location", n.Location));
            if (n.Content != null) root.Add(new XElement("Content", n.Content));
            root.Add(new XElement("CellType", n.CellType));

            return root;
        }
        public object Visit(SanityCheckingCellData n)
        {
            var root = new XElement("SanityCheckingCellData");
            if (n.Location != null) root.Add(new XElement("Location", n.Location));
            if (n.Content != null) root.Add(new XElement("Content", n.Content));
            root.Add(new XElement("CellType", n.CellType));

            return root;
        }
        public object Visit(IntermediateCellData n)
        {
            var root = new XElement("IntermediateCellData");
            if (n.Location != null) root.Add(new XElement("Location", n.Location));
            if (n.Content != null) root.Add(new XElement("Content", n.Content));
            root.Add(new XElement("CellType", n.CellType));
            root.Add(new XElement("differenceUp", n.DifferenceUp));
            root.Add(new XElement("differenceDown", n.DifferenceDown));

            return root;
        }

        public object Visit(ResultCellData n)
        {
            var root = new XElement("resultCellData");
            if (n.Location != null) root.Add(new XElement("Location", n.Location));
            if (n.Content != null) root.Add(new XElement("Content", n.Content));
            root.Add(new XElement("CellType", n.CellType));
            root.Add(new XElement("differenceUp", n.DifferenceUp));
            root.Add(new XElement("differenceDown", n.DifferenceDown));

            return root;
        }

        public object Visit(Cell n)
        {
            var root = new XElement("Cell");
            root.Add("ID", n.Id);
            root.Add("Content", NullCheck(n.Content));
            root.Add("Location", NullCheck(n.Location));

            return root;
        }

        #region private Methods

        private XElement SaveInputs(Scenario n)
        {
            var root = new XElement("Inputs");

            foreach (var input in n.Inputs)
            {
                root.Add(input.Accept(this) as XElement);
            }

            return root;
        }

        private XElement SaveIntermediates(Scenario n)
        {
            var root = new XElement("Intermediates");

            foreach (var intermediate in n.Intermediates)
            {
                root.Add(intermediate.Accept(this) as XElement);
            }

            return root;
        }

        private XElement SaveResults(Scenario n)
        {
            var root = new XElement("Results");

            foreach (var result in n.Results)
            {
                root.Add(result.Accept(this) as XElement);
            }

            return root;
        }

        private XElement SaveSanityValueCells(Scenario n)
        {
            var root = new XElement("sanityValueCells");

            foreach (var result in n.SanityValueCells)
            {
                root.Add(result.Accept(this) as XElement);
            }

            return root;
        }

        private XElement SaveSanityConstraintCells(Scenario n)
        {
            var root = new XElement("sanityConstraintCells");

            foreach (var result in n.SanityConstraintCells)
            {
                root.Add(result.Accept(this) as XElement);
            }

            return root;
        }

        private XElement SaveSanityExplanationCells(Scenario n)
        {
            var root = new XElement("SanityExplanationCells");

            foreach (var result in n.SanityExplanationCells)
            {
                root.Add(result.Accept(this) as XElement);
            }

            return root;
        }

        private XElement SaveSanityCheckingCells(Scenario n)
        {
            var root = new XElement("SanityCheckingCells");

            foreach (var result in n.SanityCheckingCells)
            {
                root.Add(result.Accept(this) as XElement);
            }

            return root;
        }
        #endregion

        private string NullCheck(string content)
        {
            return (content != null) ? content : String.Empty;
        }


        public object Visit(StaticScenarios.StaticScenario n)
        {
            throw new NotImplementedException();
        }
    }
}
