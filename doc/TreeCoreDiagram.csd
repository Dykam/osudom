<ClassProject>
  <Language>CSharp</Language>
  <Entities>
    <Entity type="Class">
      <Name>Node</Name>
      <Access>Public</Access>
      <Modifier>None</Modifier>
    </Entity>
    <Entity type="Interface">
      <Name>INode</Name>
      <Access>Public</Access>
      <Member type="Property">uint Lenght { get; }</Member>
    </Entity>
    <Entity type="Class">
      <Name>AbstractNodeList</Name>
      <Access>Public</Access>
      <Modifier>Abstract</Modifier>
    </Entity>
    <Entity type="Interface">
      <Name>INodeList</Name>
      <Access>Public</Access>
    </Entity>
    <Entity type="Class">
      <Name>NodeList</Name>
      <Access>Public</Access>
      <Modifier>None</Modifier>
    </Entity>
  </Entities>
  <Relations>
    <Relation type="Dependency" first="0" second="1" />
    <Relation type="Dependency" first="2" second="3" />
    <Relation type="Dependency" first="4" second="3" />
  </Relations>
  <Positions>
    <Shape>
      <Location left="498" top="22" />
      <Size width="162" height="216" />
    </Shape>
    <Shape>
      <Location left="56" top="2" />
      <Size width="162" height="216" />
    </Shape>
    <Shape>
      <Location left="306" top="237" />
      <Size width="162" height="216" />
    </Shape>
    <Shape>
      <Location left="32" top="283" />
      <Size width="162" height="216" />
    </Shape>
    <Shape>
      <Location left="340" top="504" />
      <Size width="162" height="216" />
    </Shape>
    <Connection>
      <StartNode isHorizontal="True" location="33" />
      <EndNode isHorizontal="True" location="33" />
    </Connection>
    <Connection>
      <StartNode isHorizontal="True" location="101" />
      <EndNode isHorizontal="True" location="118" />
    </Connection>
    <Connection>
      <StartNode isHorizontal="True" location="60" />
      <EndNode isHorizontal="True" location="199" />
    </Connection>
  </Positions>
</ClassProject>