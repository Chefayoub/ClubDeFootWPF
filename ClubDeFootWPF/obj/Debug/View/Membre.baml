   M S B A M L   `   `   `  ����H  DClubDeFootWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ClubDeFootWPF.ViewClubDeFootWPF.View  5   	       ClubDeFootWPF.View.Membre   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ClubDeFootWPF.View     5   	   -   5          � Title$  Membre��5   	   $	��450��6   $	��800��6%   $	��800��61   $	��450��6@   .��5
      � 
������� J� RenderTransformOrigin$ 
0.475,0.53&�6    � ColumnDefinitions 5   
   �� 5      $	��87* �6   �� 5      $
��707* �6   .+�5   
   �� $��Center=�6   $��	0,0,618,0q�60   $	��421��6C   $��2��6P   $��2��6a   ���	#FF0B9142.+�5      �� $-��'/ClubDeFootWPF;component/BallonFoot.png��6   $��76��6E   $��0, 10, 0, 0q�6Q   5      �� 5      $��Football club manager��6   $��0, 10, 0, 50q�64   
�������$��Arial Black)�6]   $��Center=�6v   �� 5      -   5        $��bAjouter��5      $��Ajouter��6%   $��10,10,10,20q�67   $��38��5   )   ���	#FF012FFF
�������$��Arial Black)�6_   {�5   L   ��  �� Path$ ActiverBcpFiche� �� Mode$ OneWay=���5      �� *
cAjouter+6_   �� 5      -   5        $��	bModifier��5      $��Modifier��6&   $��10,10,10,20q�69   ���	#FFFF7400
�������$��Arial Black)�5   T   $��40��6m   {�5   N   �� $ ActiverBcpFiche�$ OneWay=���5      �� *	cModifier+6m   �� 5      -   5        $��
bSupprimer��5      $��	Supprimer��6'   $��10,10,10,20q�6;   
���  ��
�������$��Arial Black)�5   O   $��35��6h   {�5   P   �� $ ActiverBcpFiche�$ OneWay=���5      �� *
cSupprimer+6h   5      �� 5   
   -   5        $��	tIDMembre��5      $��	ID Membre��6%   $��Center=�66   $��101,188,529,196q�6Q   $��37��6j   $��1��6v   �� 5   
   -   5        $��
tbIDMembre��5      $��201,187,352,201q�6$   $��1��6=   ��6M   �� $ UnMembre.ID_Membre�$ TwoWay=�{�6�   �� $ ActiverUneFiche2�$ OneWay=��� 5!   
   -   5        $��	tIDEquipe��5!      $��	ID Equipe��6%   $��Center=�66   $��100,228,530,157q�6Q   $��36��6j   $��1��6v   �� 5"   
   -   5        $��cbEquipe��5"      $��1��6#   $
��Left=�63   $��25��6N   $��201,227,0,0q�6Z   $	��Top=�6o   $	��154��6�    �� SelectedValue 6�   �� $ UnMembre.ID_Equipe�$ TwoWay=�{�6�   �� $ ActiverUneFiche�$ OneWay=��� 5%   
   -	   5        $
��tNom��5%      $	��Nom��6    $��Center=�6,   $��403,184,227,201q�6G   $��36��6`   $��1��6l   �� 5&   
   -
   5        $��tbNom��5&      $��510,184,42,211q�6   $��1��67   ��6G   �� $ UnMembre.Nom�$ TwoWay=�{�6w   �� $ ActiverUneFiche�$ OneWay=��� 5(   
   -   5        $��tPrenom��5(      $��Prenom��6#   $��Center=�62   $��402,226,228,159q�6M   $��36��6f   $��1��6r   �� 5)   
   -   5        $��tbPrenom��5)      $��510,226,43,169q�6"   $��1��6:   ��6J   �� $ UnMembre.Prenom�$ TwoWay=�{�6}   �� $ ActiverUneFiche�$ OneWay=��� 5+   
   -   5        $��tEmail��5+      $��Email��6"   $��Center=�6/   $��99,270,531,120q�6J   $��31��6b   $��1��6n   �� 5,   
   -   5        $��tbEmail��5,      $��202,266,352,124q�6!   $��1��6:   ��6J   �� $ UnMembre.Email�$ TwoWay=�{�6|   �� $ ActiverUneFiche�$ OneWay=��� 5.   
   -   5        $��
tNumeroTel��5.      $��Numero téléphone��6&   $��Center=�6>   $��94,301,509,80q�6Y   $��1��6p   $��40��6�   �� 5/   
   -   5        $��tbNumeroTel��5/      $��203,301,350,94q�6%   $��1��6=   ��6M   �� $ UnMembre.NumeroTel�$ TwoWay=�{�6�   �� $ ActiverUneFiche�$ OneWay=��� 51   
   -   5        $��tDateDeNaissance��51      $��Date de naissance��6,   $��Center=�6F   $��47��6a   $��391,280,201,94q�6m   $��1��6�   �� 52   
   -   5        $��tbDate��52      $��510,275,42,120q�6    $��1��68   ��6H   �� $ UnMembre.DateDeNaissance� �� StringFormat$ 
dd/MM/yyyy��{�6�   �� $ ActiverUneFiche�$ OneWay=��� 55   
   -   5        $��
bConfirmer��55      $��	Confirmer��6#   $��242,375,383,10q�67   $��1��56   +   ���	#FF1ECB5D$��Arial Black)�6R   {�55   O   �� $ ActiverUneFiche�$ OneWay=���56      �� *
cConfirmer+6R   �� 57   
   -   5         ��Name$ bAnnuler��57      $��Annuler��6#   $��535,375,90,10q�65   $��1��58   )   ���	#FFF00D0D$��Arial Black)�6P   {�57   L   �� *ActiverUneFiche+$ OneWay=���58      �� *
cAnnuler+6P   &   System.Windows.Controls.DataGrid  5;   
   -   5        $��dgMembre��5;      "   VerticalScrollBarVisibility$ Visible=�6K   	   
IsReadOnly	 . 
   AutoGenerateColumns
 .  $��95,35,9,247q�5=   t   $��1��6�   ��5;   #   �� $ 
BcpMembres�{�5<   ;   �� $ ActiverBcpFiche�$ OneWay=� �� SelectedItem 5=      �� *MembreSelectionnee+$ TwoWay=�   Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$ 	ID Membre��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� $ 	ID_Membre�6[     5@      $ 	ID Equipe��6%   $ * 6[    68   �� $ 	ID_Equipe�6[     5A      $	 Nom��6%   $ * 6O    62   �� $	 Nom�6O     5B      $ Prenom��6%   $ * 6U    65   �� $ Prenom�6U     5C      $ Email��6%   $ * 6S    64   �� $ Email�6S     5D      $ Numero téléphone��6%   $ * 6b    6?   �� $ 	NumeroTel�6b     5E      $ Date de naissance��6%   $ * 6�    6@   �� $ DateDeNaissance�$ 
dd/MM/yyyy��6�   5G      �� 5H   
   -   5         ��Name$ 	tNomTitre��5H      $��Membre��6'   $��Center=�66   $��338,8,292,377q�6Q   $��36��6h   $��1��6t   $��Arial Black)�6�   $��16(�6�   �� 5I   
   -   5         ��Name$ rtbDoc��5I      $
��Left=�6'   $��36��6B   $��87.8,334,0,0q�6N   $	��Top=�6d   $	��609��6|   $��1��6�   . �5J      /� .T�5K      J� 5L      5M      5P      5R      