   M S B A M L   `   `   `  ����H  DClubDeFootWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ClubDeFootWPF.ViewClubDeFootWPF.View  5   	        ClubDeFootWPF.View.Terrain   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ClubDeFootWPF.View     5   	     � Title$  Terrain��5   	   $	��450��6   $	��800��6&   $	��800��62   $	��450��6A   .��5
      � 
������� J� RenderTransformOrigin$ 
0.475,0.53&�6    � ColumnDefinitions 5   
   �� 5      $	��87* �6   �� 5      $
��707* �6   .+�5   
   �� $��Center=�6   $��	0,0,618,0q�60   $	��421��6C   $��2��6P   $��2��6a   ���	#FF0B9142.+�5      �� $-��'/ClubDeFootWPF;component/BallonFoot.png��6   $��76��6E   $��0, 10, 0, 0q�6Q   5      �� 5      $��Football club manager��6   $��0, 10, 0, 50q�64   
�������$��Arial Black)�6]   $��14(�6v   $��Center=�6�   �� 5      -   5        $��bAjouter��5      $��Ajouter��6%   $��10,10,10,20q�67   $��38��5   )   ���	#FF012FFF
�������$��Arial Black)�6_   $��16(�6x   {�5   L   ��  �� Path$ ActiverBcpFiche� �� Mode$ OneWay=���5      �� *
cAjouter+6x   �� 5      -   5        $��	bModifier��5      $��Modifier��6&   $��10,10,10,20q�69   ���	#FFFF7400
�������$��Arial Black)�5   T   $��16(�6m   $��40��6{   {�5   N   �� $ ActiverBcpFiche�$ OneWay=���5      �� *	cModifier+6{   �� 5      -   5        $��
bSupprimer��5      $��	Supprimer��6'   $��10,10,10,20q�6;   
���  ��
�������$��Arial Black)�5   O   $��16(�6h   $��35��6v   {�5   P   �� $ ActiverBcpFiche�$ OneWay=���5      �� *
cSupprimer+6v   5      �� 5   
   -   5        $��
tIDTerrain��5      $��
ID Terrain��6&   $��Center=�68   $��113,256,518,127q�6S   $��38��6l   $��1��6x   �� 5   
   -   5        $��tbIDTerrain��5      $��1��6%   $��195,256,358,131q�65   ��6N   �� $ UnTerrain.ID_Terrain�$ TwoWay=�{�6�   �� $ ActiverUneFiche2�$ OneWay=��� 5!   
   -   5        $
��tNom��5!      $	��Nom��6    $��Center=�6+   $��406,256,225,129q�6F   $��36��6_   $��1��6k   �� 5"   
   -   5        $��tbNom��5"      $��487,256,68,133q�6   $��1��67   ��6G   �� $ UnTerrain.Nom�$ TwoWay=�{�6x   �� $ ActiverUneFiche�$ OneWay=��� 5%   
   -   5        $��
bConfirmer��5%      $��	Confirmer��6#   $��242,375,383,10q�67   $��1��5&   +   ���	#FF1ECB5D$��Arial Black)�6R   {�5%   O   �� $ ActiverUneFiche�$ OneWay=���5&      �� *
cConfirmer+6R   �� 5'   
   -	   5         ��Name$ bAnnuler��5'      $��Annuler��6#   $��535,375,90,10q�65   $��1��5(   )   ���	#FFF00D0D$��Arial Black)�6P   {�5'   L   �� *ActiverUneFiche+$ OneWay=���5(      �� *
cAnnuler+6P   &   System.Windows.Controls.DataGrid  5+   
   -
   5        $��	dgTerrain��5+      $��2��6M   "   VerticalScrollBarVisibility$ Visible=�6Z      
IsReadOnly .    AutoGenerateColumns .  $��94,70,10,189q�5-   w   $��1��6�   ��5+   $   �� $ BcpTerrains�{�5,   ;   �� $ ActiverBcpFiche�$ OneWay=�	 �� SelectedItem	 5-      �� *TerrainSelectionnee+$ TwoWay=�
   Columns
 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ 
ID Terrain��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� $ 
ID_Terrain�6]     50      $	 Nom��6%   $ * 6O    62   �� $	 Nom�6O   52      �� 54   
   -   5         ��Name$ tTerrainName��54      $��Terrain��6*   $��Center=�69   $��348,10,208,377q�6T   $��34��6l   $��1��6x   $��Arial Black)�6�   $��18(�6�   55      57      