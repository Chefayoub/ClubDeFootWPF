   M S B A M L   `   `   `  ����H  DClubDeFootWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ClubDeFootWPFClubDeFootWPF  5   	       ClubDeFootWPF.Accueil   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ClubDeFootWPF     5   	   -   5          �Name$
  load��5   	    � Title$ Accueil��5   	   $	��638��6   $
��1044��6&   $	��638��63   $
��1044��6C    � 	Resources 5
      &   System.Windows.Controls.Calendar �� 
TargetType   DateTimeCalendar �� Property �� Value��%�   &	        �� 5   
   "  6   .�5      ��  � ��
 ��ح�6+   �� 5       � ��
 ��  �6,   �� 5       � ��$ 5q�60   �� 5       �@ DisplayMode$ Decade=�6,   5      5      .��5      � $��0,0,-6,0q�6    � ColumnDefinitions 5   
   �� 5      $	��87* �6   �� 5      $
��707* �6   .+�5   
   �� $��
0,-6,841,0q�6   $��2��6)   ���	#FF0B9142$	��615��6T   $	��Top=�6a   .+�5      �� -   5         ��Name$	 cli��5      $��BallonFoot.png��6!   $��84��69   $��0, 30, 0, 0q�6E    J� OpacityMask 5      �� 5      	 �� ImageSource$	 BallonFoot.png��6!   
 j� Stretch$
 Uniform=�6>   5!      �� 5"      $��Football club manager��6   $��24,10,10,30q�65   
�������$��Arial Black)�6]   $��Center=�6v   $��30��6�   $	��169��6�   �� 5#      -   5         ��Name$ 	btnEquipe��5#      $��Equipe��6(   $��	5,5,5.2,5q�69   $��40��6d   
�������$��Arial Black)�6�   $��14(�6�   ���	#FF042B046�   �� 5$      -   5        $ 	btnMembre��5$      $��Membre��6(   $��	5,5,5.2,5q�69   $��40��6d   
�������$��Arial Black)�6�   $��14(�6�   ���	#FF042B046�   �� 5%      -   5        $��btnMatch��5%      $��Match��6%   $��5q�65   $��40��6W   
�������$��Arial Black)�6v   $��14(�6�   ���	#FF042B046�   �� 5&      -   5        $ 
btnTerrain��5&      $��Terrain��6)   $��	5,5,5.2,5q�6;   $��40��6g   
�������$��Arial Black)�6�   $��14(�6�   ���	#FF042B046�   �� 5'      -   5        $��btnEntrainement��5'      $��Entrainement��6,   $��5q�6C   $��40��6l   
�������$��Arial Black)�6�   $��14(�6�   ���	#FF042B046�   �� 5(      -   5        $ btnClub��5(      $
��Club��6&   $��	5,5,5.2,5q�65   $��40��6^   
�������$��Arial Black)�6}   $��14(�6�   ���	#FF042B046�   �� 5)      -	   5        $ btnMail��5)      $
��Mail��6&   $��	5,5,5.2,5q�65   $��40��6^   
�������$��Arial Black)�6}   $��14(�6�   ���	#FF042B046�   �� 5*      -
   5        $ btnHTML��5*      $
��HTML��6&   $��	5,5,5.2,5q�65   $��40��6^   
�������$��Arial Black)�6}   $��14(�6�   ���	#FF042B046�   5+      &   System.Windows.Controls.DataGrid  53   
   -   5          Name$ dgEquipe��53      "   VerticalScrollBarVisibility$ Visible=�6H      
IsReadOnly .    AutoGenerateColumns .  $��93.6,261,597,194.8q�55   t   $��1��6�   $��Arial)�6�      RowDetailsVisibilityMode$ Visible=�6�   ��53   %   �� *
BcpEquipes+{�54   ;   �� *ActiverBcpFiche+ �� Mode$ OneWay=� �� SelectedItem 55      �� *EquipeSelectionnee+$ TwoWay=�   Columns 56      0  *System.Windows.Controls.DataGridTextColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header$ 	ID Equipe��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *	ID_Equipe+6V     58      $ ID Club��6%   $ * 6R    66   �� *	ID_Club+6R     59      $	 Nom��6%   $ * 6J    62   �� *Nom+6J   5;      �� 5<   
   -   5         ��Name$ tEquipeName��5<      $��Equipe��6)   $��Center=�67   $��150,225,682,355q�6R   $��29��6k   $��1��6w   $��Arial Black)�6�   $��18(�6�     5?   
   -   5        $ dgMembre��5?      $ Visible=�6H    .  .  $��353,93,14,378q�5A   t   $��1��6�   $��Arial)�6�   ��5?   %   �� *
BcpMembres+{�5@   ;   �� *ActiverBcpFiche+$ OneWay=� 5A      �� *MembreSelectionnee+$ TwoWay=� 5B        5C      $ 	ID Membre��6%   $ * 6V    68   �� *	ID_Membre+6V     5D      $ 	ID Equipe��6%   $ * 6V    68   �� *	ID_Equipe+6V     5E      $	 Nom��6%   $ * 6J    62   �� *Nom+6J     5F      $ Prenom��6%   $ * 6P    65   �� *Prenom+6P     5G      $ Email��6%   $ * 6N    64   �� *Email+6N     5H      $ Numero téléphone��6%   $ * 6]    6?   �� *	NumeroTel+6]     5I      $ Date de naissance��6%   $ * 6}    6@   �� *DateDeNaissance+ �� StringFormat$ 
dd/MM/yyyy��6}   5K      �� 5L   
   -   5        $ tMembreName��5L      $��Membre��6)   $��Center=�67   $��581,63,225,521q�6R   $��25��6j   $��1��6v   $��Arial Black)�6�   $��18(�6�     5O   
   -   5        $ 	dgTerrain��5O      $ Visible=�6J    .  .  $��89.6,457,601,9.8q�5Q   w   $��1��6�   $��Arial)�6�   $ Visible=�6�   ��5O   &   �� *BcpTerrains+{�5P   ;   �� *ActiverBcpFiche+$ OneWay=� 5Q      �� *TerrainSelectionnee+$ TwoWay=� 5R        5S      $ 
ID Terrain��6%   $ * 6X    69   �� *
ID_Terrain+6X     5T      $	 Nom��6%   $ * 6J    62   �� *Nom+6J   5V      �� 5W   
   -   5        $ tTerrainName��5W      $��Terrain��6*   $��Center=�69   $��147.6,419,682,156.8q�6T   $��33��6q   $��1��6}   $��Arial Black)�6�   $��18(�6�     5Z   
   -   5        $ dgMatch��5Z      $ Visible=�6F    .  .  $��353,266,14,195q�5\   r   $��1��6�   $��Arial)�6�   ��5Z   $   �� *	BcpMatchs+{�5[   ;   �� *ActiverBcpFiche+$ OneWay=� 5\      �� *MatchSelectionnee+$ TwoWay=� 5]        5^      $ ID Match��6%   $ * 6T    67   �� *
ID_Match+6T     5_      $ ID Domicile��6%   $ * 6Z    6:   �� *ID_Domicile+6Z     5`      $ ID Deplacement��6%   $ * 6`    6=   �� *ID_Deplacement+6`     5a      $ 
ID Terrain��6%   $ * 6X    69   �� *
ID_Terrain+6X     5b      $ Score Domicile��6%   $ * 6`    6=   �� *Score_Domicile+6`     5c      $ Score Adversaire��6%   $ * 6d    6?   �� *Score_Adversaire+6d     5d      $
 Date��6%   $ * 6n    63   �� *DateM+$ dd/MM/yyyy HH:mm��6n     5e      $ CarteJaune_Domicile��6%   $ * 6o    6B   ��  �� Path$ CarteJaune_Domicile�6o     5f      $ CarteRouge_Domicile��6%   $ * 6o    6B   �� $ CarteRouge_Domicile�6o     5g      $ CarteJaune_Adversaire��6%   $ * 6s    6D   �� $ CarteJaune_Adversaire�6s     5h      $ CarteRouge_Adversaire��6%   $ * 6s    6D   �� $ CarteRouge_Adversaire�6s   5j      �� 5k   
   -   5        $ 
tMatchName��5k      $��Match��6(   $��Center=�65   $��581,236,262,348q�6P   $��25��6i   $��1��6u   $��Arial Black)�6�   $��18(�6�     5n   
   -   5        $ dgEntrainement��5n      $ Visible=�6T    .  .  $��353,459,14,7q�5p   �   $��1��6�   $��Arial)�6�   ��5n   +   �� *BcpEntrainements+{�5o   ;   �� *ActiverBcpFiche+$ OneWay=� 5p      �� *EntrainementSelectionnee+$ TwoWay=� 5q        5r      $ ID Entrainement��6%   $ * 6b    6>   �� *ID_Entrainement+6b     5s      $ 
ID Terrain��6%   $ * 6X    69   �� *
ID_Terrain+6X     5t      $ 	ID Equipe��6%   $ * 6V    68   �� *	ID_Equipe+6V     5u      $
 Date��6%   $ * 6n    63   �� *DateE+$ dd/MM/yyyy HH:mm��6n   5w      �� 5x   
   -   5        $ tEntrainementName��5x      $��Entrainement��6/   $��Center=�6C   $��581,428,174,157q�6^   $��24��6w   $��1��6�   $��Arial Black)�6�   $��18(�6�   �� 5z   
   -   5        $��rtbDoc��5z      $
��Left=�6$   $��0��6?   $��
58,609,0,0q�6J   $	��Top=�6^   $��56��6v   $��Arial)�6�   {�.  ��6�   Z� . �5{      /� .T�5|      J� .*�6   .*�5}      �� $� ��6   5~      5      5�      �� 5�   
   -   5        $ bGenererFichierID��5�      $��187,97,687,473q�6,   $��1��6D   $��Arial Black)�6T   ��6m   Z� ��6�   Z� ��5�      �� 5�      $	 View/floppy-disk.png��6   $
 Uniform=�6@   5�      �� 5�   
   -   5         ��Name$ tbGenererFichierID��5�      $��126,96,747,472q�6.   $��1��6F   �� 5�   
   -   5        $ bGenererFichierIDEnvoyer��5�      $��128,167,753,394q�63   $��1��6L   $��Arial Black)�6\   ��6u   Z� ��6�   Z� ��5�      �� 5�      $	 	email.png��6   $
 Uniform=�65   5�      �� 5�   
   $,��&Sauvegarder le programme de la semaine��6   $��1��6A   $
��Left=�6Q   $��	89,71,0,0q�6l   $	��Top=�6   $	��245��6�   $��Italic$�6�   �� 5�   
   $(��"Envoyer le programme de la semaine��6   $��1��6=   $
��Left=�6M   $��
88,141,0,0q�6h   $	��Top=�6|   $	��245��6�   $��Italic$�6�   �� 5�   
   -   5        $ tbGenererFichierID_Copy��5�      $��187,172,686,398q�63   $��1��6L   �� 5�   
   $8��2Veuillez indiquer l'ID de l'équipe déterminée :��6   $��1��6J   $
��Left=�6Z   $��	89,45,0,0q�6u   $	��Top=�6�   $	��266��6�   $
��Bold"�6�   �� 5�   
   $��Remplir��6   $��1��6#   $
��Left=�63   $��
824,16,0,0q�6N   $	��Top=�6b   $��75��6z   $��24��6�   $��Arial Black)�6�   ���	#FF2075A6
����  �
���������6�   �� *remplirTableEntrainement+6  �� 5�   
   -   5        $ tbRemplirTableDate��5�      $��1��6.   $
��Left=�6>   $��23��6Y   $��
699,17,0,0q�6e    �� TextWrapping$
 Wrap=�6y   $	��Top=�6�   $	��120��6�   ��6�   �� $ DateEntrainement�$ dd/MM/yyyy HH:mm���� 5�   
   $W��QSelectionner une equipe , un terrain et indiquer la date d'entrainement souhaiter��6   $��1��6l   $
��Left=�6|   $��
221,11,0,0q�6�   $	��Top=�6�   $	��473��6�   $
��Bold"�6�   $��29��6�   5�      5�      