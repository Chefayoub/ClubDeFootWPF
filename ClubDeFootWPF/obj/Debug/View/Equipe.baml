   M S B A M L   `   `   `  ����H  DClubDeFootWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ClubDeFootWPF.ViewClubDeFootWPF.View  5   	       ClubDeFootWPF.View.Equipe   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ClubDeFootWPF.View     5   	   -   5          � Title$  Equipe��5   	   $	��450��6   $	��800��6&   $	��800��62   $	��450��6A   .��5
      � 
������� J� RenderTransformOrigin$ 
0.475,0.53&�6    � ColumnDefinitions 5   
   �� 5      $	��87* �6   �� 5      $
��707* �6   .+�5   
   �� $��Center=�6   $��	0,0,618,0q�60   $	��421��6C   $��2��6P   $��2��6a   ���	#FF0B9142.+�5      �� $-��'/ClubDeFootWPF;component/BallonFoot.png��6   $��76��6E   $��0, 10, 0, 0q�6Q   5      �� 5      $��Football club manager��6   $��0, 10, 0, 50q�64   
�������$��Arial Black)�6]   $��Center=�6v   �� 5      -   5        $��bAjouter��5      $��Ajouter��6%   $��10,10,10,20q�67   $��38��5   )   ���	#FF012FFF
�������$��Arial Black)�6_   {�5   L   ��  �� Path$ ActiverBcpFiche� �� Mode$ OneWay=���5      �� *
cAjouter+6_   �� 5      -   5        $��	bModifier��5      $��Modifier��6&   $��10,10,10,20q�69   ���	#FFFF7400
�������$��Arial Black)�5   T   $��40��6m   {�5   N   �� $ ActiverBcpFiche�$ OneWay=���5      �� *	cModifier+6m   �� 5      -   5        $��
bSupprimer��5      $��	Supprimer��6'   $��10,10,10,20q�6;   
���  ��
�������$��Arial Black)�5   O   $��35��6h   {�5   P   �� $ ActiverBcpFiche�$ OneWay=���5      �� *
cSupprimer+6h   5      �� 5   
   -   5        $��	tIDEquipe��5      $��	ID Equipe��6%   $��Center=�66   $��113,256,518,127q�6Q   $��38��6j   $��1��6v   �� 5   
   -   5        $��
tbIDEquipe��5      $��1��6$   $��195,256,358,131q�64   ��6M   �� $ UneEquipe.ID_Equipe�$ TwoWay=�{�6�   �� $ ActiverUneFiche2�$ OneWay=��� 5!   
   -   5        $��tIDClub��5!      $��ID Club��6#   $��Center=�62   $��113,298,518,87q�6M   $��36��6e   $��1��6q   �� 5"   
   -   5        $��cbClub��5"      $��1��6!   $
��Left=�61   $��25��6L   $��195,299,0,0q�6X   $	��Top=�6m   $	��154��6�    �� SelectedValue 6�   �� $ UneEquipe.ID_Club�$ TwoWay=�{�6�   �� $ ActiverUneFiche�$ OneWay=��� 5$   
   -	   5        $
��tNom��5$      $	��Nom��6    $��Center=�6+   $��423,254,208,131q�6F   $��36��6_   $��1��6k   �� 5%   
   -
   5        $��tbNom��5%      $��1��6   $��503,254,50,131q�6/   ��6G   �� $ UneEquipe.Nom�$ TwoWay=�{�6x   �� $ ActiverUneFiche�$ OneWay=��� 5(   
   -   5        $��
bConfirmer��5(      $��	Confirmer��6#   $��242,375,383,10q�67   $��1��5)   +   ���	#FF1ECB5D$��Arial Black)�6R   {�5(   O   �� $ ActiverUneFiche�$ OneWay=���5)      �� *
cConfirmer+6R   �� 5*   
   -   5         ��Name$ bAnnuler��5*      $��Annuler��6#   $��535,375,90,10q�65   $��1��5+   )   ���	#FFF00D0D$��Arial Black)�6P   {�5*   L   �� *ActiverUneFiche+$ OneWay=���5+      �� *
cAnnuler+6P   &   System.Windows.Controls.DataGrid  5.   
   -   5        $��dgEquipe��5.      $��2��6K   "   VerticalScrollBarVisibility$ Visible=�6X      
IsReadOnly . 	   AutoGenerateColumns	 .  $��94,70,10,189q�50   u   $��1��6�   ��5.   #   �� $ 
BcpEquipes�{�5/   ;   �� $ ActiverBcpFiche�$ OneWay=�
 �� SelectedItem
 50      �� *EquipeSelectionnee+$ TwoWay=�   Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$ 	ID Equipe��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� $ 	ID_Equipe�6[     53      $ ID Club��6%   $ * 6W    66   �� $ ID_Club�6W     54      $	 Nom��6%   $ * 6O    62   �� $	 Nom�6O   56      �� 58   
   -   5         ��Name$ tEquipeName��58      $��Equipe��6)   $��Center=�67   $��348,10,208,377q�6R   $��34��6j   $��1��6v   $��Arial Black)�6�   $��22(�6�   5;      5<      