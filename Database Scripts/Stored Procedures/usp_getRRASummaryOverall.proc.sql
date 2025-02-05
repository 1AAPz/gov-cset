-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_getRRASummaryOverall]
@assessment_id int
AS
BEGIN
	SET NOCOUNT ON;

	select a.Answer_Full_Name, a.Answer_Text, 
		isnull(m.qc,0) as [qc],
		isnull(m.Total,0) as [Total], 
		IsNull(Cast(IsNull(Round((Cast((qc) as float)/(IsNull(NullIf(Total,0),1)))*100, 2), 0) as float),0) as [Percent] 
	from 
	(select * from ANSWER_LOOKUP 
	where answer_text in ('Y','N','U') ) a left join (
SELECT a.Answer_Text, isnull(count(question_or_requirement_id),0) qc , SUM(count(Question_Or_Requirement_Id)) OVER(PARTITION BY assessment_id) AS Total
			FROM Answer_Maturity a 
			join MATURITY_LEVELS l on a.Maturity_Level = l.Maturity_Level_Id
			where a.Assessment_Id = @assessment_id and Is_Maturity = 1 --@assessment_id 
			group by a.Assessment_Id, a.Answer_Text)
			m on a.Answer_Text=m.Answer_Text		
	JOIN ANSWER_ORDER o on a.Answer_Text=o.answer_text
	order by o.answer_order

END



