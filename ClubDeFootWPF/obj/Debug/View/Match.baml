   M S B A M L   `   `   `  ����H  DClubDeFootWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ClubDeFootWPF.ViewClubDeFootWPF.View  5   	       ClubDeFootWPF.View.Match   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ClubDeFootWPF.View     5   	   -   5          � Title$  Match��5   	   $	��450��6   $��1174.655��6$   $	��450��66   .��5
      � 
������� J� RenderTransformOrigin$ 
0.475,0.53&�6    � ColumnDefinitions 5   
   �� 5      $	��87* �6   �� 5      $
��707* �6   .+�5   
   �� $��Center=�6   $��	0,0,957,0q�60   $	��420��6C   $��2��6P   ���	#FF0B9142.+�5      �� $-��'/ClubDeFootWPF;component/BallonFoot.png��6   $��76��6E   $��0, 10, 0, 0q�6Q   5      �� 5      $��Football club manager��6   $��0, 10, 0, 50q�64   
�������$��Arial Black)�6]   $��Center=�6v   �� 5      -   5        $��bAjouter��5      $��Ajouter��6%   $��10,10,10,20q�67   $��38��5   .   ���	#FF012FFF
�������$��Arial Black)�6d   {�5   L   ��  �� Path$ ActiverBcpFiche� �� Mode$ OneWay=���5      �� *
cAjouter+6d   �� 5      -   5        $��	bModifier��5      $��Modifier��6&   $��10,10,10,20q�69   ���	#FFFF7400
�������$��Arial Black)�5   Y   $��40��6r   {�5   N   �� $ ActiverBcpFiche�$ OneWay=���5      �� *	cModifier+6r   �� 5      -   5        $��
bSupprimer��5      $��	Supprimer��6'   $��10,10,10,20q�6;   
���  ��
�������$��Arial Black)�5   T   $��35��6m   {�5   P   �� $ ActiverBcpFiche�$ OneWay=���5      �� *
cSupprimer+6m   5      �� 5   
   -   5        $��tIDMatch��5      $��ID Match��6$   $��Center=�64   $��94,206,857,194q�6O   $��20��6g   $��1��6s   �� 5   
   -   5        $��	tbIDMatch��5      $��188,201,698,194q�6#   $��1��6<   ��6L   �� $ UnMatch.ID_Match�$ TwoWay=�{�6�   �� $ ActiverUneFiche2�$ OneWay=��� 5!   
   -   5        $��tIDDomicile��5!      $��ID Domicile��6'   $��Center=�6:   $��94,244,857,158q�6U   $��18��6m   $��1��6y   �� 5"   
   -   5        $��cbIDDomicile��5"      $��1��6'   $
��Left=�67   $��25��6R   $��187.8,237,0,0q�6^   $	��Top=�6u   $	��154��6�    �� SelectedValue 6�   �� $ UnMatch.ID_Domicile�$ TwoWay=�{�6�   �� $ ActiverUneFiche�$ OneWay=��� 5%   
   -	   5        $��tIDDeplacement��5%      $��ID Deplacement��6*   $��Center=�6@   $��94,272,857,126q�6[   $��22��6s   $��1��6   �� 5&   
   -
   5        $��cbIDDeplacement��5&      $��1��6*   $
��Left=�6:   $��24��6U   $��187.8,272,0,0q�6a   $	��Top=�6x   $	��154��6�    6�   �� $ UnMatch.ID_Deplacement�$ TwoWay=�{�6�   �� $ ActiverUneFiche�$ OneWay=��� 5(   
   -   5        $��
tIDTerrain��5(      $��
ID Terrain��6&   $��Center=�68   $��94,308,868,92q�6S   $��20��6j   $��1��6v   �� 5)   
   -   5        $��cbIDTerrain��5)      $��1��6&   $
��Left=�66   $��24��6Q   $��187.8,305,0,0q�6]   $	��Top=�6t   $	��154��6�    6�   �� $ UnMatch.ID_Terrain�$ TwoWay=�{�6�   �� $ ActiverUneFiche�$ OneWay=��� 5,   
   -   5        $��tScoreDomicile��5,      $��Score Domicile��6*   $��Center=�6@   $��381,202,570,188q�6[   $��30��6t   $��1��6�   �� 5-   
   -   5        $��tbScoreDomicile��5-      $��475,199,445,196q�6)   $��1��6B   ��6R   �� $ UnMatch.Score_Domicile�$ TwoWay=�{�6�   �� $ ActiverUneFiche�$ OneWay=��� 5/   
   -   5        $��tScoreAdversaire��5/      $��Score Adversaire��6,   $��Center=�6D   $��381,238,570,158q�6_   $��1��6x   $��24��6�   �� 50   
   -   5        $��tbScoreAdversaire��50      $��475,237,445,158q�6+   $��1��6D   ��6T   �� $ UnMatch.Score_Adversaire�$ TwoWay=�{�6�   �� $ ActiverUneFiche�$ OneWay=��� 52   
   -   5        $��tDateM��52      $
��Date��6"   $��Center=�6.   $��26��6I   $��381,276,570,118q�6U   $��1��6n   �� 53   
   -   5         ��Name$ tDateMm��53      $��475,277,445,118q�6#   $��1��6<   ��6L   �� $ UnMatch.DateM�$ TwoWay=� �� StringFormat$ dd/MM/yyyy HH:mm��{�6�   �� $ ActiverUneFiche�$ OneWay=��� 57   
   -   5        $��
bConfirmer��57      $��	Confirmer��6#   $��242,375,555,10q�67   $��1��58   +   ���	#FF1ECB5D$��Arial Black)�6R   {�57   O   �� $ ActiverUneFiche�$ OneWay=���58      �� *
cConfirmer+6R   �� 59   
   -   5         ��Name$ bAnnuler��59      $��Annuler��6#   $��535,375,237,10q�65   $��1��5:   )   ���	#FFF00D0D$��Arial Black)�6P   {�59   M   �� *ActiverUneFiche+$ OneWay=���5:      �� *
cAnnuler+6P   &   System.Windows.Controls.DataGrid  5=   
   -   5        $��dgMatch��5=      $��2��6I   "	   VerticalScrollBarVisibility$	 Visible=�6V   
   
IsReadOnly
 .    AutoGenerateColumns .  $��94,49,10,233q�5?   n   $��1��6�   ��5=   "   �� $ 	BcpMatchs�{�5>   7   �� $ ActiverBcpFiche�$ OneWay=� �� SelectedItem 5?   	   �� *MatchSelectionnee+$ TwoWay=�   Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$ ID Match��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� $ ID_Match�6Y     5B      $ ID Domicile��6%   $ * 6_    6:   �� $ ID_Domicile�6_     5C      $ ID Deplacement��6%   $ * 6e    6=   �� $ ID_Deplacement�6e     5D      $ 
ID Terrain��6%   $ * 6]    69   �� $ 
ID_Terrain�6]     5E      $ Score Domicile��6%   $ * 6e    6=   �� $ Score_Domicile�6e     5F      $ Score Adversaire��6%   $ * 6i    6?   �� $ Score_Adversaire�6i     5G      $
 Date��6%   $ * 6s    63   �� $ DateM�$ dd/MM/yyyy HH:mm��6s     5I      $ CarteJaune_Domicile��6%   $ * 6o    6B   �� $ CarteJaune_Domicile�6o     5J      $ CarteRouge_Domicile��6%   $ * 6o    6B   �� $ CarteRouge_Domicile�6o     5K      $ CarteJaune_Adversaire��6%   $ * 6s    6D   �� $ CarteJaune_Adversaire�6s     5L      $ CarteRouge_Adversaire��6%   $ * 6s    6D   �� $ CarteRouge_Adversaire�6s   5N      �� 5P   
   -   5         ��Name$ 
tMatchName��5P      $��Match��6(   $��Center=�65   $��344.8,10,257.6,376q�6P   $��34��6l   $��1��6x   $��Arial Black)�6�   $��16(�6�   �� 5R   
   -   5        $��rtbDoc��5R      $
��Left=�6%   $��36��6@   $��87.8,334,0,0q�6L   $	��Top=�6b   $	��609��6z   $��1��6�   . �5S      /� .T�5T      J� .*�6   5U      5V      5W      �� 5Y   
   -   5        $ tCarteJaune_Domicile��5Y      $��Center=�62   $��731,200,162,190q�6M   $��30��6f   $��1��6r   �� 6�   $�Carte jaune��6�   �� 6�   $�	 Domicile��6�   6�   �� 5Z   
   -   5        $ tbCarteJaune_Domicile��5Z      $��884,197,36,198q�61   $��1��6I   ��6Y   �� *UnMatch.CarteJaune_Domicile+$ TwoWay=�{�6�   �� *ActiverUneFiche+$ OneWay=��� 5[   
   -   5        $ tCarteRouge_Domicile��5[      $��Carte rougeDomicile��62   $��Center=�6M   $��731,236,162,160q�6h   $��1��6�   $��24��6�   �� 5\   
   -   5        $ tbCarteRouge_Domicile��5\      $��884,235,36,160q�61   $��1��6I   ��6Y   �� *UnMatch.CarteRouge_Domicile+$ TwoWay=�{�6�   �� *ActiverUneFiche+$ OneWay=��� 5]   
   -   5        $ tCarteJaune_Adversaire��5]      $��Carte jaune Adversaire��64   $��Center=�6R   $��731,281,161,109q�6m   $��30��6�   $��1��6�   �� 5^   
   -   5        $ tbCarteJaune_Adversaire��5^      $��884,278,36,117q�63   $��1��6K   ��6[   �� *UnMatch.CarteJaune_Adversaire+$ TwoWay=�{�6�   �� *ActiverUneFiche+$ OneWay=��� 5_   
   -   5        $ tCarteRouge_Adversaire��5_      $��Carte rouge Adversaire��64   $��Center=�6R   $��731,317,161,79q�6m   $��1��6�   $��24��6�   �� 5`   
   -   5        $ tbCarteRouge_Adversaire��5`      $��884,316,36,79q�63   $��1��6J   ��6Z   �� *UnMatch.CarteRouge_Adversaire+$ TwoWay=�{�6�   �� *ActiverUneFiche+$ OneWay=�5a      5f      