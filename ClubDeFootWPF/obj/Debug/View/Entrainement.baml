   M S B A M L   `   `   `  ����H  DClubDeFootWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ClubDeFootWPF.ViewClubDeFootWPF.View  5   	   %    ClubDeFootWPF.View.Entrainement   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ClubDeFootWPF.View     5   	   -   5          � Title$  Entrainement��5   	   $	��450��6   $	��800��6,   $	��800��68   $	��450��6G   .��5
      � 
������� J� RenderTransformOrigin$ 
0.475,0.53&�6    � ColumnDefinitions 5   
   �� 5      $	��87* �6   �� 5      $
��707* �6   .+�5   
   �� $��Center=�6   $��	0,0,618,0q�60   $	��421��6C   $��2��6P   $��2��6a   ���	#FF0B9142.+�5      �� $-��'/ClubDeFootWPF;component/BallonFoot.png��6   $��76��6E   $��0, 10, 0, 0q�6Q   5      �� 5      $��Football club manager��6   $��0, 10, 0, 40q�64   
�������$��Arial Black)�6]   $��Center=�6v   �� 5      -   5        $��bAjouter��5      $��Ajouter��6%   $��10,10,10,20q�67   $��38��5   )   ���	#FF012FFF
�������$��Arial Black)�6_   {�5   L   ��  �� Path$ ActiverBcpFiche� �� Mode$ OneWay=���5      �� *
cAjouter+6_   �� 5      -   5        $��	bModifier��5      $��Modifier��6&   $��10,10,10,20q�69   ���	#FFFF7400
�������$��Arial Black)�5   T   $��40��6m   {�5   N   �� $ ActiverBcpFiche�$ OneWay=���5      �� *	cModifier+6m   �� 5      -   5        $��
bSupprimer��5      $��	Supprimer��6'   $��10,10,10,20q�6;   
���  ��
�������$��Arial Black)�5   O   $��35��6h   {�5   P   �� $ ActiverBcpFiche�$ OneWay=���5      �� *
cSupprimer+6h   5      �� 5    
   -   5        $��tIDEntrainement��5       $��ID Entrainement��6+   $��Center=�6B   $��113,256,500,127q�6]   $��38��6v   $��1��6�   �� 5!   
   -   5        $��tbIDEntrainement��5!      $��1��6*   $��212,256,341,131q�6:   ��6S   �� $$ UnEntrainement.ID_Entrainement�$ TwoWay=�{�6�   �� $ ActiverUneFiche2�$ OneWay=��� 5#   
   -   5        $��
tIDTerrain��5#      $��
ID Terrain��6&   $��Center=�68   $��113,298,518,87q�6S   $��36��6k   $��1��6w   �� 5$   
   -   5        $��cbIDTerrain��5$      $��1��6&   $
��Left=�66   $��25��6Q   $��212,298,0,0q�6]   $	��Top=�6r   $	��154��6�    �� SelectedValue 6�   �� $ UnEntrainement.ID_Terrain�$ TwoWay=�{�6�   �� $ ActiverUneFiche�$ OneWay=��� 5&   
   -	   5        $��	tIDEquipe��5&      $��	ID Equipe��6%   $��Center=�66   $��423,254,208,131q�6Q   $��36��6j   $��1��6v   �� 5'   
   -
   5        $��cbEquipe��5'      $��1��6#   $
��Left=�63   $��25��6N   $��503,254,0,0q�6Z   $	��Top=�6o   $	��154��6�    6�   �� $ UnEntrainement.ID_Equipe�$ TwoWay=�{�6�   �� $ ActiverUneFiche�$ OneWay=��� 5)   
   -   5        $��tDateE��5)      $
��Date��6"   $��Center=�6.   $��423,296,208,89q�6I   $��36��6a   $��1��6m   �� 5*   
   -   5         ��Name$ tDateEe��5*      $��503,296,50,99q�6#   $��1��6:   ��6J   �� $ UnEntrainement.DateE�$ TwoWay=� �� StringFormat$ dd/MM/yyyy HH:mm��{�6�   �� $ ActiverUneFiche�$ OneWay=��� 5-   
   -   5        $��
bConfirmer��5-      $��	Confirmer��6#   $��242,375,383,10q�67   $��1��5.   +   ���	#FF1ECB5D$��Arial Black)�6R   {�5-   O   �� $ ActiverUneFiche�$ OneWay=���5.      �� *
cConfirmer+6R   �� 5/   
   -   5         ��Name$ bAnnuler��5/      $��Annuler��6#   $��535,375,90,10q�65   $��1��50   )   ���	#FFF00D0D$��Arial Black)�6P   {�5/   L   �� *ActiverUneFiche+$ OneWay=���50      �� *
cAnnuler+6P   &   System.Windows.Controls.DataGrid  53   
   -   5        $��dgEntrainement��53      "	   VerticalScrollBarVisibility$	 Visible=�6W   
   
IsReadOnly
 .    AutoGenerateColumns .  $��96,87,8,172q�55   �   $��1��6�   ��53   )   �� $ BcpEntrainements�{�54   ;   �� $ ActiverBcpFiche�$ OneWay=� �� SelectedItem 55      �� *EntrainementSelectionnee+$ TwoWay=�   Columns 56      0  *System.Windows.Controls.DataGridTextColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header$ ID Entrainement��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� $ ID_Entrainement�6g     58      $ 
ID Terrain��6%   $ * 6]    69   �� $ 
ID_Terrain�6]     59      $ 	ID Equipe��6%   $ * 6[    68   �� $ 	ID_Equipe�6[     5:      $
 Date��6%   $ * 6s    63   �� $ DateE�$ dd/MM/yyyy HH:mm��6s   5<      �� 5>   
   -   5         ��Name$ tEntrainementName��5>      $��Entrainement��6/   $��Center=�6C   $��318,10,238,377q�6^   $��34��6v   $��1��6�   $��Arial Black)�6�   $��16(�6�   �� 5?   
   -   5         ��Name$ rtbDoc��5?      $
��Left=�6'   $��36��6B   $��87.8,334,0,0q�6N   $	��Top=�6d   $	��609��6|   $��1��6�   . �5@      /� .T�5A      J� .*�6   5B      5C      5D      �� 5E   
   -   5        $ bGenererFichierID��5E      $��654,9,-4,381q�6,   $��1��6B   $��Arial Black)�6R   ��6k   Z� ��6�   Z� ��5F      �� 5G       �� ImageSource$ floppy-disk.png��6    j� Stretch$ Uniform=�6;   5I      �� 5J   
   -   5        $ tbGenererFichierID��5J      $��598,12,53,381q�6.   $��28��6E   $��1��6Q   �� 5K   
   -   5        $ tIDTerrain_Copy��5K      $��Center=�6-   $��541,17,90,382q�6H   $��22��6_   $��1��6k   �� 6}   $	�ID ��6�   �� 6�   $�Equipe��6�   6�   �� 5L   
   $:��4L'horaire d'entraînement d'une équipe déterminée��6   $��1��6K   $
��Left=�6[   $��
423,39,0,0q�6v   $	��Top=�6�   5N      5P      