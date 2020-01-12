Imports System.Xml
Imports System.IO

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim xmldoc As New XmlDataDocument()
        Dim xmlnode As XmlNode
        Dim fs As New FileStream("tree.xml", FileMode.Open, FileAccess.Read)
        xmldoc.Load(fs)
        xmlnode = xmldoc.ChildNodes(1)
        TreeView1.Nodes.Clear()
        TreeView1.Nodes.Add(New TreeNode(xmldoc.DocumentElement.Name))
        Dim tNode As TreeNode
        tNode = TreeView1.Nodes(0)
        AddNode(xmlnode, tNode)

    End Sub

    Private Sub AddNode(ByVal inXmlNode As XmlNode, ByVal inTreeNode As TreeNode)
        Dim xNode As XmlNode
        Dim tNode As TreeNode
        Dim nodeList As XmlNodeList
        Dim i As Integer
        If inXmlNode.HasChildNodes Then
            nodeList = inXmlNode.ChildNodes
            For i = 0 To nodeList.Count - 1
                xNode = inXmlNode.ChildNodes(i)
                inTreeNode.Nodes.Add(New TreeNode(xNode.Name))
                tNode = inTreeNode.Nodes(i)
                AddNode(xNode, tNode)
            Next
        Else
            inTreeNode.Text = inXmlNode.InnerText.ToString
        End If
    End Sub
End Class

