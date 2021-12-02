﻿using CSETWebCore.Helpers;
using CSETWebCore.Model.Assessment;
using CSETWebCore.Model.Edm;
using CSETWebCore.Business.Reports;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using CSETWebCore.Interfaces.Crr;
using CSETWebCore.Model.Crr;

namespace CSETWebCore.Reports.Models
{
    public class CrrViewModel : PageModel
    {
        public CrrViewModel(AssessmentDetail assessmentDetails, 
            string criticalService,
            ICrrScoringHelper crrScores,
            MaturityBasicReportData reportData
            )
        {
            AssessmentDetails = assessmentDetails;
            CriticalService = criticalService;
            CRRScores = crrScores;
            ReportData = reportData;
            PageNumbers = new Dictionary<string, int>();
        }
        public CrrResultsModel crrResultsData { get; set; }

        public AssessmentDetail AssessmentDetails { get; set; }

        public List<EdmScoreParent> ParentScores { get; set; }

        public ICrrScoringHelper CRRScores { get; set; }

        public CrrReportChart ReportChart { get; set; }

        public string CriticalService { get; set; }

        public MaturityBasicReportData ReportData { get; set; }

        public Dictionary<string, int> PageNumbers { get; set; }

        public bool IncludeResultsStylesheet { get; set; }
    }

}