   M S B A M L   `   `   `  ����H  DClubDeFootWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ClubDeFootWPF.ViewClubDeFootWPF.View  5   	       ClubDeFootWPF.View.Club   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ClubDeFootWPF.View     5   	     � Title$
  Club��5   	   $	��450��6   $	��800��6#   $	��800��6/   $	��450��6>   .��5      � 
������� J� RenderTransformOrigin$ 
0.475,0.53&�6    � ColumnDefinitions 5   
   �� 5      $	��87* �6   �� 5      $
��707* �6   .+�5   
   �� $��Center=�6   $��	0,0,618,0q�60   $	��421��6C   $��2��6P   $��2��6a   ���	#FF0B9142.+�5      �� $-��'/ClubDeFootWPF;component/BallonFoot.png��6   $��76��6E   $��0, 10, 0, 0q�6Q   5      �� 5      $��Football club manager��6   $��0, 10, 0, 50q�64   
�������$��Century)�6]   $��14(�6r   $��Center=�6�   �� 5      -   5        $��bAjouter��5      $��Ajouter��6%   $��10,10,10,20q�67   $��38��5   )   ���	#FF012FFF
�������$��Century)�6_   $��16(�6t   {�5   L   ��  �� Path$ ActiverBcpFiche� �� Mode$ OneWay=���5      �� *
cAjouter+6t   �� 5      -   5        $��	bModifier��5      $��Modifier��6&   $��10,10,10,20q�69   ���	#FFFF7400
�������$��Century)�5   T   $��16(�6i   $��40��6w   {�5   N   �� $ ActiverBcpFiche�$ OneWay=���5      �� *	cModifier+6w   �� 5      -   5        $��
bSupprimer��5      $��	Supprimer��6'   $��10,10,10,20q�6;   
���  ��
�������$��Century)�5   O   $��16(�6d   $��35��6r   {�5   P   �� $ ActiverBcpFiche�$ OneWay=���5      �� *
cSupprimer+6r   5      �� 5   
   -   5        $��tIDClub��5      $��ID Club��6#   $��Center=�62   $��115,201,516,183q�6M   $��37��6f   $��1��6r   �� 5   
   -   5        $��tbIDClub��5      $��196,201,357,187q�6"   $��1��6m   ��6;   �� $ UnClub.ID_Club�$ TwoWay=�{�6}   �� $ ActiverUneFiche2�$ OneWay=��� 5    
   -   5        $
��tNom��5       $	��Nom��6    $��Center=�6+   $��115,243,516,142q�6F   $��36��6_   $��1��6k   �� 5!   
   -   5        $��tbNom��5!      $��196,243,358,146q�6   $��1��6f   ��68   �� $ 
UnClub.Nom�$ TwoWay=�{�6v   �� $ ActiverUneFiche�$ OneWay=��� 5#   
   -   5        $
��tRue��5#      $	��Rue��6    $��Center=�6+   $��424,198,207,187q�6F   $��36��6_   $��1��6k   �� 5$   
   -	   5        $��tbRue��5$      $��505,198,48,187q�6   $��1��6e   ��67   �� $ 
UnClub.Rue�$ TwoWay=�{�6u   �� $ ActiverUneFiche�$ OneWay=��� 5&   
   -
   5        $��tNumero��5&      $��Numéro��6#   $��Center=�61   $��424,240,207,145q�6L   $��36��6e   $��1��6q   �� 5'   
   -   5        $��tbNumero��5'      $��505,240,49,145q�6"   $��1��6k   ��6:   �� $ UnClub.Numero�$ TwoWay=�{�6{   �� $ ActiverUneFiche�$ OneWay=��� 5)   
   -   5        $	��tCP��5)      $��Code Postal��6   $��Center=�62   $��116,280,515,110q�6M   $��31��6f   $��1��6r   �� 5*   
   -   5        $
��tbCP��5*      $��197,280,357,110q�6   $��1��6m   ��67   �� $ UnClub.Code_Postal�$ TwoWay=�{�6}   �� $ ActiverUneFiche�$ OneWay=��� 5,   
   -   5        $��	tLocalite��5,      $��Localite��6%   $��Center=�65   $��116,317,515,64q�6P   $��1��6h   $��40��6x   �� 5-   
   -   5        $��
tbLocalite��5-      $��197,322,357,73q�6$   $��1��6o   ��6<   �� $ UnClub.Localite�$ TwoWay=�{�6   �� $ ActiverUneFiche�$ OneWay=��� 5/   
   -   5        $��tMonClub��5/      $��Mon Club��6$   $��Center=�64   $��47��6O   $��424,292,207,82q�6[   $��1��6s   �� 50   
   -   5        $��	tbMonClub��50      $��505,292,49,96q�6#   $��1��6m   ��6:   �� $ UnClub.Mon_Club�$ TwoWay=�{�6}   �� $ ActiverUneFiche�$ OneWay=��� 52   
   -   5        $��
bConfirmer��52      $��	Confirmer��6#   $��242,375,383,10q�67   $��1��53   +   ���	#FF1ECB5D{�52   O   �� $ ActiverUneFiche�$ OneWay=���53      �� *
cConfirmer+6;   �� 54   
   -   5         ��Name$ bAnnuler��54      $��Annuler��6#   $��535,375,90,10q�65   $��1��55   )   ���	#FFF00D0D{�54   L   �� *ActiverUneFiche+$ OneWay=���55      �� *
cAnnuler+69   &   System.Windows.Controls.DataGrid  57   
   -   5        $��dgClub��57      "   VerticalScrollBarVisibility$ Visible=�6G      
IsReadOnly .    AutoGenerateColumns .  $��94,49,10,233q�59   p   $��1��6�   ��57   !   �� $ BcpClubs�{�58   ;   �� $ ActiverBcpFiche�$ OneWay=�	 �� SelectedItem	 59      �� *ClubSelectionnee+$ TwoWay=�
   Columns
 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� $ ID_Club�6R     5<      $	 Nom��6%   $ * 6O    62   �� $	 Nom�6O     5=      $	 Rue��6%   $ * 6O    62   �� $	 Rue�6O     5>      $ Numero��6%   $ * 6U    65   �� $ Numero�6U     5?      $ CP��6%   $ * 6V    61   �� $ Code_Postal�6V     5@      $ Localite��6%   $ * 6Y    67   �� $ Localite�6Y     5A      $ Mon club��6%   $ * 6Y    67   �� $ Mon_Club�6Y   5C      �� 5D   
   -   5         ��Name$ 	tclubName��5D      $
��Club��6'   $��Center=�63   $��369,10,262,377q�6N   $��34��6f   $��1��6r   $��Century)�6�   $��22(�6�   �� 5E   
   $��1��6   $
��Left=�6"   $��76��6=   $��135,322,0,0q�6I    �� TextWrapping$
 Wrap=�6^   $��TextBox��6r   $	��Top=�6�   $	��120��6�   5F      5G      