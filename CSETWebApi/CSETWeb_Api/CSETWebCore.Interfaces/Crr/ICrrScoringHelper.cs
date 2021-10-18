﻿using System.Collections.Generic;
using System.Xml.Linq;
using CSETWebCore.DataLayer;
using CSETWebCore.Model.Crr;
using CSETWebCore.Model.Maturity;
using CSETWebCore.Model.Question;
using CSETWebCore.Reports.Models;

namespace CSETWebCore.Interfaces.Crr
{
    public interface ICrrScoringHelper
    {
        public int AssessmentId { get; set; }
        public int CrrModelId { get;}
        public XDocument XDoc { get; set; }
        public XDocument XCsf { get; set; }
        public void InstantiateScoringHelper(int assessmentId);
        public void LoadStructure();
        public CrrResultsModel GetCrrResultsSummary();
        public void GetSubgroups(XElement xE, int? parentID,
            List<MATURITY_GROUPINGS> allGroupings,
            List<MATURITY_QUESTIONS> questions,
            List<FullAnswer> answers);

        public void ManipulateStructure();
        public void Rollup();
        CrrReportChart GetPercentageOfPractice();
        public string GetColor(XElement xE);
        public void SetColor(XElement xE, string color);
        public Dictionary<string, string> CsfFunctionColors { get; }
        public string B2S(bool b);

        public AnswerColorDistrib FullAnswerDistrib();
        public AnswerColorDistrib MIL1FullAnswerDistrib();
        public AnswerColorDistrib DomainAnswerDistrib(string domainAbbrev);
        public AnswerColorDistrib MIL1DomainAnswerDistrib(string domainAbbrev);
        public AnswerColorDistrib GoalAnswerDistrib(string domainAbbrev, string goalAbbrev);
        public AnswerColorDistrib CrrReferenceAnswerDistrib(XElement element);
    }
}